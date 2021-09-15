using System;
using System.Collections.Generic;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class VisitedLesson
    {
        public int Id { get; set; }

        public int LessonId { get; set; }

        public Lesson Lesson { get; set; }

        public int MemberId { get; set; }

        public Member Member { get; set; }

        public DateTime Date { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<Timecode> Timecodes { get; set; }
    }
}
