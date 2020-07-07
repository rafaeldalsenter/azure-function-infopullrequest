using System;

namespace AzureFunctionGithub.CrossCutting
{
    public static class EnvironmentVariables
    {
        public static string GetGithubToken() =>
            Environment.GetEnvironmentVariable("GITHUB_TOKEN", EnvironmentVariableTarget.Process);
        
        public static string GetGithubUser() =>
            Environment.GetEnvironmentVariable("GITHUB_USER", EnvironmentVariableTarget.Process);
    }
}