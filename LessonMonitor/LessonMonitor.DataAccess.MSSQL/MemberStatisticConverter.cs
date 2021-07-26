using AutoMapper;
using System.Collections.Generic;

namespace LessonMonitor.DataAccess.MSSQL
{
    public class MemberStatisticConverter : ITypeConverter<Entities.Member, Core.MemberStatistic[]>
    {
        public Core.MemberStatistic[] Convert(
            Entities.Member source,
            Core.MemberStatistic[] destination,
            ResolutionContext context)
        {
            var result = new List<Core.MemberStatistic>();

            foreach (var visitedLesson in source.VisitedLessons)
            {
                var statistic = new Core.MemberStatistic
                {
                    MemberName = source.Name,
                    LessonDate = visitedLesson.Lesson.StartDate,
                    LessonTitle = visitedLesson.Lesson.Title,
                    LessonVisitedDate = visitedLesson.Date,
                    QuestiontsQuantity = visitedLesson.Questions.Count,
                    TimecodesQuantity = visitedLesson.Timecodes.Count,
                    IsHomeworkDone = visitedLesson.Homework.Done
                };

                result.Add(statistic);
            }

            return result.ToArray();
        }
    }
}
