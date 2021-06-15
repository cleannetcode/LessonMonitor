using LessonMonitor.Core.Exceprions;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;
using System;

namespace LessonMonitor.BussinesLogic
{
    public class HomeworksService : IHomeworksService
    {
        private readonly IHomeworksRepository _homeworksRepository;

        public const string HOMEWORK_IS_INVALID = "Homework link should not be null or whitespace!";

        public HomeworksService(IHomeworksRepository homeworksRepository)
        {
            _homeworksRepository = homeworksRepository;
        }

        public Core.Homework Get()
        {
            throw new NotImplementedException();
        }

        public bool Create(Core.Homework homework)
        {
            // Валидация
            if(homework is null) throw new ArgumentNullException(nameof(homework));
            
            var isInvalid = string.IsNullOrWhiteSpace(homework.Id.ToString())
                || string.IsNullOrWhiteSpace(homework.Grade.ToString()) 
                || Guid.Empty == homework.Id;

            if (isInvalid) throw new HomeworkException(HOMEWORK_IS_INVALID);
            
            // сохранение в базе
            _homeworksRepository.Add(homework);

            return true;
        }

        public bool Delete(Guid homeworkId)
        {
            // Валидация
            if(homeworkId == Guid.Empty) throw new HomeworkException(HOMEWORK_IS_INVALID);

            // сохранение в базе
            _homeworksRepository.Delete(homeworkId);

            return true;
        }

        public bool Update(Core.Homework homework)
        {
            if (homework is null) throw new ArgumentNullException(nameof(homework));

            // Валидация
            var isInvalid = string.IsNullOrWhiteSpace(homework.Id.ToString())
               || string.IsNullOrWhiteSpace(homework.Grade.ToString())
               || Guid.Empty == homework.Id;

            if (isInvalid) throw new HomeworkException(HOMEWORK_IS_INVALID);

            // сохранение в базе
            _homeworksRepository.Update(homework);

            return true;
        }
    }
}
