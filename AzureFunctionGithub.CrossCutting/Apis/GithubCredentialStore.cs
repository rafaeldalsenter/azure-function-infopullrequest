using System.Threading.Tasks;
using Octokit;

namespace AzureFunctionGithub.CrossCutting.Apis
{
    public class GithubCredentialStore : ICredentialStore
    {
        public Task<Credentials> GetCredentials() => Task.FromResult(new Credentials(EnvironmentVariables.GetGithubToken()));
    }
}