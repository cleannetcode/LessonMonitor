using LessonMonitor.Core;
using LessonMonitor.Core.Exceprions;
using LessonMonitor.Core.Models;
using System;

namespace LessonMonitor.BussinesLogic
{
    public class HomeworksService
    {
        private readonly IHomeworksRepository _homeworksRepository;

        public const string HOMEWORK_IS_INVALID = "Homework link should not be null or whitespace!";

        public HomeworksService(IHomeworksRepository homeworksRepository)
        {
            _homeworksRepository = homeworksRepository;
        }


        public bool Create(Homework homework)
        {
            // Валидация
            if(homework is null)
            {
                throw new ArgumentNullException(nameof(homework));
            }

            var isInvalid = string.IsNullOrWhiteSpace(homework.Link) 
                || string.IsNullOrWhiteSpace(homework.Title) 
                || homework.MemberId <= 0;


            if (isInvalid)
            {
                throw new BusinessException(HOMEWORK_IS_INVALID);
            }

            // сохранение в базе
            _homeworksRepository.Add(homework);

            return true;
        }

        public bool Delete(int homeworkId)
        {
            // Валидация

            // сохранение в базе
            _homeworksRepository.Delete(homeworkId);

            return true;
        }
    }
}
