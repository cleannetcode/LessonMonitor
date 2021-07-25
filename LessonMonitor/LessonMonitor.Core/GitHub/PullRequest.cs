namespace LessonMonitor.Core.GitHub
{
    public class PullRequest
    {
        public long Id { get; set; }

        public int GithubAccountId { get; set; }

        public string ToBranchName { get; set; }

        public string FromBranchName { get; set; }

        public bool IsApproved { get; set; }

        public string Url { get; set; }
    }
}
