# azure-function-infopullrequest
⚡ Azure Function to obtain pull-requests information

Project created for this article: [Azure Function to capture data from Github using OctoKit](https://medium.com/@rafaeldalsenter/azure-function-to-capture-data-from-github-using-octokit-78ff7c801642)

A simple Azure function that communicates with the Github API (using [Octokit](https://github.com/octokit/octokit.net)) and get some information about the changed files in Pull-request:
- Number of files changed.
- Amount of Csproj files changed.
- If any external references have been updated (Up now compatible with C# repositories).

Input parameters for function: **repositoryId** and **pullrequest** number.
Environment variables required: **GITHUB_TOKEN** and **GITHUB_USER**.

| CodeFactor | Deploy |
|:---:|:---:|
|[![CodeFactor](https://www.codefactor.io/repository/github/rafaeldalsenter/azure-function-infopullrequest/badge?s=3149a4afc7e40658669bb35acd25e95da1ec2f00)](https://www.codefactor.io/repository/github/rafaeldalsenter/azure-function-infopullrequest)|![Deploy Azure function App](https://github.com/rafaeldalsenter/azure-function-infopullrequest/workflows/Deploy%20Azure%20function%20App/badge.svg)|
