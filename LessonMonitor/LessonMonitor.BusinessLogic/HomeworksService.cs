using LessonMonitor.Core;
using LessonMonitor.Core.Exeptions;
using LessonMonitor.Core.Repository;
using LessonMonitor.Core.Service;
using System;

namespace LessonMonitor.BusinessLogic
{
    public class HomeworksService : IHomeworksService
    {
        public const string HOMEWORK_IS_INVALID = "Homework is invalid!";
        private readonly IHomeworksRepository homeworksRepository;
        public HomeworksService(IHomeworksRepository homeworksRepository)
        {
            this.homeworksRepository = homeworksRepository;
        }
        public bool Create(Homework homework)
        {
            if (homework is null)
            {
                throw new ArgumentNullException(nameof(homework));
            }
            var isInvalid = String.IsNullOrWhiteSpace(homework.Link)
                || String.IsNullOrWhiteSpace(homework.Title)
                || homework.MemberId <= 0;

            if (isInvalid)
            {
                throw new BusinessException(HOMEWORK_IS_INVALID);
            }

            homeworksRepository.Add(homework);
            return true;
        }
        public bool Delete(int homeworksId)
        {
            homeworksRepository.Delete(homeworksId);
            return true;
        }
    }
}
