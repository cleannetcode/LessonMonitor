using System;

namespace LessonMonitor.Core
{
    public class MemberStatistic
    {
        public string LessonTitle { get; set; }

        public DateTime LessonDate { get; set; }

        public string MemberName { get; set; }

        public DateTime LessonVisitedDate { get; set; }

        public int QuestiontsQuantity { get; set; }

        public int TimecodesQuantity { get; set; }

        public bool IsHomeworkDone { get; set; }
    }
}
