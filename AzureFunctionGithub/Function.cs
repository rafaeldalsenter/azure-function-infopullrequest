using System;
using System.IO;
using System.Threading.Tasks;
using AzureFunctionGithub.CrossCutting;
using AzureFunctionGithub.CrossCutting.Apis;
using AzureFunctionGithub.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Auth;
using Newtonsoft.Json;
using Octokit;

namespace AzureFunctionGithub
{
    public static class Function
    {
        [FunctionName("Function")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            if (!long.TryParse(req.Query["repositoryId"], out var repositoryId))
                return new BadRequestObjectResult("Param repositoryId incorrect!");

            if (!int.TryParse(req.Query["pullRequest"], out var pullRequest))
                return new BadRequestObjectResult("Param pullRequest incorrect!");

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var result = await serviceProvider
                .GetService<IPullRequestInfoServices>()
                .Get(repositoryId, pullRequest);

            return new OkObjectResult(JsonConvert.SerializeObject(result));
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            var teste = EnvironmentVariables.GetGithubUser();
            
            serviceCollection.AddTransient<ICsprojFileServices, CsprojFileServices>();
            serviceCollection.AddTransient<IPullRequestInfoServices, PullRequestInfoServices>();
            serviceCollection.AddTransient<IGithubConnection, GithubConnection>();
            serviceCollection.AddTransient<IGitHubClient, GitHubClient>(x 
                => new GitHubClient(new ProductHeaderValue(EnvironmentVariables.GetGithubUser()), new GithubCredentialStore()));
        }
    }
}