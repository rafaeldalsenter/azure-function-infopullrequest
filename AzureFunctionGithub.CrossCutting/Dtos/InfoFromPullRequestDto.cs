using System.Collections;
using System.Collections.Generic;

namespace AzureFunctionGithub.CrossCutting.Dtos
{
    public class InfoFromPullRequestDto
    {
        public IEnumerable<string> ChangedReferences { get; set; }
        public int ChangedFiles { get; set; }
        public int ChangedCsprojFiles { get; set; }
    }
}