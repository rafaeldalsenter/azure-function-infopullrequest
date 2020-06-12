# azure-function-infopullrequest
⚡ Azure Function to obtain pull-requests information

A simple Azure function that communicates with the Github API (using [Octokit](https://github.com/octokit/octokit.net)) and get some information about the changed files in Pull-request:
- Number of files changed.
- Amount of Csproj files changed.
- If any external references have been updated (Up now compatible with C# repositories).

Input parameters for function: repositoryId and pullrequest number.
Environment variables required: GITHUB_TOKEN and GITHUB_USER.

| CodeFactor |
|:---:|
|[![CodeFactor](https://www.codefactor.io/repository/github/rafaeldalsenter/azure-function-infopullrequest/badge?s=3149a4afc7e40658669bb35acd25e95da1ec2f00)](https://www.codefactor.io/repository/github/rafaeldalsenter/azure-function-infopullrequest)|
