using System;
using System.Collections.Generic;
using System.Text;

namespace LessonMonitor.Core
{
    public class GitHubAccount
    {
        public int MemberId { get; set; }

        public string Nickname { get; set; }

        public Uri Link { get; set; }

        public int GithubAccountId { get; set; }

        public Member Member { get; set; }
    }
}
