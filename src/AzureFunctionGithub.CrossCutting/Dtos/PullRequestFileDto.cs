namespace AzureFunctionGithub.CrossCutting.Dtos
{
    public class PullRequestFileDto
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public int Additions { get; set; }
        public int Deletions { get; set; }
    }
}