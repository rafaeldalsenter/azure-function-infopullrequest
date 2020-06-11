using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureFunctionGithub.CrossCutting.Apis;
using AzureFunctionGithub.CrossCutting.Dtos;
using AzureFunctionGithub.CrossCutting.Extensions;

namespace AzureFunctionGithub.Services
{
    public class PullRequestInfoServices : IPullRequestInfoServices
    {
        private readonly IGithubConnection _githubConnection;
        private readonly ICsprojFileServices _csprojFileServices;

        public PullRequestInfoServices(IGithubConnection githubConnection,
            ICsprojFileServices csprojFileServices)
        {
            _githubConnection = githubConnection;
            _csprojFileServices = csprojFileServices;
        }

        public async Task<InfoFromPullRequestDto> Get(long repositoryId, int pullRequest)
        {
            var changedCsprojFiles = new List<string>();

            var pullRequestFiles = await _githubConnection.GetFilesFromPullRequest(repositoryId, pullRequest);

            pullRequestFiles
                .Where(x => x.FileName.IsCsProjFile())
                .ToList()
                .ForEach(x => { changedCsprojFiles.AddRange(_csprojFileServices.GetChangedReferences(x.Path)); });

            return new InfoFromPullRequestDto
            {
                ChangedFiles = pullRequestFiles.Count(),
                ChangedCsprojFiles = pullRequestFiles.Count(x => x.FileName.IsCsProjFile()),
                ChangedReferences = changedCsprojFiles
            };
        }
    }
}