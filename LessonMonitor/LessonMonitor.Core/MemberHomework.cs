namespace LessonMonitor.Core
{
    public class MemberHomework
    {
        public int MemberId { get; set; }

        public string Url { get; set; }

        public string ToBranchName { get; set; }

        public string FromBranchName { get; set; }

        public bool IsApproved { get; set; }
    }
}
