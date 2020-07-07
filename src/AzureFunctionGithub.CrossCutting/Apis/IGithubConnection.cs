using System.Collections.Generic;
using System.Threading.Tasks;
using AzureFunctionGithub.CrossCutting.Dtos;

namespace AzureFunctionGithub.CrossCutting.Apis
{
    public interface IGithubConnection
    {
        Task<IList<PullRequestFileDto>> GetFilesFromPullRequest(long repositoryId, int pullRequest);
    }
}