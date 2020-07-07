using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureFunctionGithub.CrossCutting.Dtos;
using Octokit;

namespace AzureFunctionGithub.CrossCutting.Apis
{
    public class GithubConnection : IGithubConnection
    {
        private readonly IGitHubClient _githubClient;
        
        public GithubConnection(IGitHubClient githubClient)
        {
            _githubClient = githubClient;
        }

        public async Task<IList<PullRequestFileDto>> GetFilesFromPullRequest(long repositoryId, int pullRequest)
        {
            var result = await _githubClient.PullRequest.Files(repositoryId, pullRequest);

            return result.Select(x => new PullRequestFileDto
            {
                Additions = x.Additions,
                Deletions = x.Deletions,
                Path = x.Patch,
                FileName = x.FileName
            }).ToList();
        }
    }
}