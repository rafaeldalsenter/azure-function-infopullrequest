using System.Collections.Generic;
using System.Threading.Tasks;
using AzureFunctionGithub.CrossCutting.Dtos;

namespace AzureFunctionGithub.Services
{
    public interface IPullRequestInfoServices
    {
        Task<InfoFromPullRequestDto> Get(long repositoryId, int pullRequest);
    }
}