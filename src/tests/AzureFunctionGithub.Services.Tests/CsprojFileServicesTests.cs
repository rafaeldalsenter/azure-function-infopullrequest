using System.IO;
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

        private string ReadTxtFromFakeFile(string fileName)
        {
            return File.ReadAllText($"./FakeFiles/{fileName}");
        }
        
        [Fact]
        public void GetChangedReferences_WithMultipleReferencesChanged()
        {
            var path = ReadTxtFromFakeFile("TwoChangedReferences.txt");
            var resultExpected = new string[2]{ "System.Data", "System.Generics"};

            var result = _csprojFileServices.GetChangedReferences(path);
            
            Assert.Collection(result, x => Assert.Equal(resultExpected[0], x),
                x => Assert.Equal(resultExpected[1], x));
        }

        [Fact]
        public void GetChangedReferences_WithOneReferenceChanged()
        {
            var path = ReadTxtFromFakeFile("OneChangedReferences.txt");
            var resultExpected = "System.Data";

            var result = _csprojFileServices.GetChangedReferences(path);
            
            Assert.Collection(result, x => Assert.Equal(resultExpected, x));
        }

        [Fact]
        public void GetChangedReferences_WithoutReferenceChanged()
        {
            var path = ReadTxtFromFakeFile("NoneChangedReferences.txt");

            var result = _csprojFileServices.GetChangedReferences(path);
            
            Assert.Empty(result);
        }
    }
}