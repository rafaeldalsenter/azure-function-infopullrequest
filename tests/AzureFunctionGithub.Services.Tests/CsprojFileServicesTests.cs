using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AzureFunctionGithub.Services.Tests
{
    public class CsprojFileServicesTests
    {
        private readonly ICsprojFileServices _csprojFileServices;
        
        public CsprojFileServicesTests()
        {
            _csprojFileServices = new CsprojFileServices();    
        }
        
        [Fact]
        public void GetChangedReferences_WithMultipleReferencesChanged()
        {
            var path = "";
            var resultExpected = new string[3]{ "System.Data", "System.Generics", "Sys.Hrg"};

            var result = _csprojFileServices.GetChangedReferences(path);
            
            Assert.Collection(result, x => Assert.Equal(resultExpected[0], x),
                x => Assert.Equal(resultExpected[1], x),
                x => Assert.Equal(resultExpected[2], x));
        }

        [Fact]
        public void GetChangedReferences_WithOneReferenceChanged()
        {
            var path = "";
            var resultExpected = "System.Data";

            var result = _csprojFileServices.GetChangedReferences(path);
            
            Assert.Collection(result, x => Assert.Equal(resultExpected, x));
        }

        [Fact]
        public void GetChangedReferences_WithoutReferenceChanged()
        {
            var path = "";

            var result = _csprojFileServices.GetChangedReferences(path);
            
            Assert.Empty(result);
        }

        [Fact]
        public void GetChangedReferences_WithoutChanged()
        {
            var path = "";

            var result = _csprojFileServices.GetChangedReferences(path);
            
            Assert.Empty(result);
        }
    }
}