using LessonMonitor.Core.CoreModels;
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

        public Homework Get()
        {
            throw new NotImplementedException();
        }

        public bool Create(Homework homework)
        {
            // Валидация
            if (homework is null) throw new ArgumentNullException(nameof(homework));

            var isInvalid = string.IsNullOrWhiteSpace(homework.Name)
                            || homework.Id <= 0;

            if (isInvalid) throw new HomeworkException(HOMEWORK_IS_INVALID);
            
            // сохранение в базе
            _homeworksRepository.Add(homework);

            return true;
        }

        public bool Delete(int homeworkId)
        {
            // Валидация
            if(homeworkId < 0) throw new HomeworkException(HOMEWORK_IS_INVALID);

            // сохранение в базе
            _homeworksRepository.Delete(homeworkId);

            return true;
        }

        public bool Update(Core.CoreModels.Homework homework)
        {
            if (homework is null) throw new ArgumentNullException(nameof(homework));

            // Валидация
            var isInvalid = string.IsNullOrWhiteSpace(homework.Name)
                           || homework.Id <= 0;

            if (isInvalid) throw new HomeworkException(HOMEWORK_IS_INVALID);

            // сохранение в базе
            _homeworksRepository.Update(homework);

            return true;
        }
    }
}
