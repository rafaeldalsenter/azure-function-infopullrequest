using System.Collections;
using System.Collections.Generic;

namespace AzureFunctionGithub.Services
{
    public interface ICsprojFileServices
    {
        IEnumerable<string> GetChangedReferences(string path);
    }
}