using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AzureFunctionGithub.CrossCutting.Extensions;

namespace AzureFunctionGithub.Services
{
    public class CsprojFileServices : ICsprojFileServices
    {
        public IEnumerable<string> GetChangedReferences(string path)
        {
            var pathJoin = path.Split(new[] {"\n"}, StringSplitOptions.None);

            return pathJoin.Where(x => x.IsRowAddition() &&
                                       x.IsReferenceIncludePattern())
                .Select(x => x.RowFormatReferenceInclude());
        }
    }
}