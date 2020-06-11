using System;
using AzureFunctionGithub.CrossCutting.Extensions;
using Xunit;

namespace AzureFunctionGithub.CrossCutting.Tests
{
    public class CsprojRowExtensionsTests
    {
        [Theory]
        [InlineData("+    <Reference Include=\"System.dll\"")]
        [InlineData("+ <Reference Include=\"System.dll\",test test test")]
        [InlineData("<Reference Include=\"System.dll\",other test test")]
        public void IsReferenceIncludePattern_IsMatch(string row)
        {
            var result = row.IsReferenceIncludePattern();
            Assert.True(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("+    <Refereence Include=\"System.dll\"")]
        [InlineData("+ <Reference Includ")]
        [InlineData("test test test")]
        public void IsReferenceIncludePattern_IsNoMatch(string row)
        {
            var result = row.IsReferenceIncludePattern();
            Assert.False(result);
        }

        [Theory]
        [InlineData("+    <Reference Include=\"System.dll\"", "System.dll")]
        [InlineData("<Reference Include=\"System.dll\"", "System.dll")]
        [InlineData("+    <Reference Include=\"OneName.LastName.dll\"", "OneName.LastName.dll")]
        public void RowFormatReferenceInclude_IsOneItem(string row, string expected)
        {
            var result = row.RowFormatReferenceInclude();
            Assert.Equal(result, expected);
        }
        
        [Theory]
        [InlineData("+    <Reference Include=\"System.dll,Version=tal,Other.dll\"", "System.dll")]
        [InlineData("<Reference Include=\"System.dll,Other.dll\"", "System.dll")]
        [InlineData("+    <Reference Include=\"OneName.LastName.dll,Test.dll\"", "OneName.LastName.dll")]
        public void RowFormatReferenceInclude_IsTwoOrMoreItem(string row, string expected)
        {
            var result = row.RowFormatReferenceInclude();
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void RowFormatReferenceInclude_Invalid(string row)
        {
            var result = row.RowFormatReferenceInclude();
            Assert.Null(result);
        }

        [Fact]
        public void IsRowAddition_IsMatch()
        {
            var result = "+ ".IsRowAddition();
            Assert.True(result);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void IsRowAddition_IsNoMatch(string value)
        {
            var result = value.IsRowAddition();
            Assert.False(result);
        }

        [Theory]
        [InlineData("Teste.csproj")]
        [InlineData("OutroTeste.csproj")]
        public void IsCsProjFile_IsMatch(string value)
        {
            var result = value.IsCsProjFile();
            Assert.True(result);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Teste.cspro")]
        [InlineData("OutroTeste.dll")]
        public void IsCsProjFile_IsNoMatch(string value)
        {
            var result = value.IsCsProjFile();
            Assert.False(result);
        }
    }
}