using LessonMonitor.Core.CoreModels;
using LessonMonitor.Core.Exceprions;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;
using System;
using System.Threading.Tasks;

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

        public async Task<int> Create(Homework homework)
        {
            if (homework is null) throw new ArgumentNullException(nameof(homework));

            var isInvalid = string.IsNullOrWhiteSpace(homework.Title)
                            || string.IsNullOrWhiteSpace(homework.Description)
                            || homework.Link == null;

            if (isInvalid) throw new HomeworkException(HOMEWORK_IS_INVALID);
            
            var homeworkId = await _homeworksRepository.Add(homework);

            if(homeworkId != default)
            {
                return homeworkId;
            }
            else
            {
                return default;
            }
        }

        public async Task<bool> Delete(int homeworkId)
        {
            if(homeworkId == default) throw new HomeworkException(HOMEWORK_IS_INVALID);

            return await _homeworksRepository.Delete(homeworkId);
        }

        public async Task<int> Update(Core.CoreModels.Homework homework)
        {
            if (homework is null) throw new ArgumentNullException(nameof(homework));

            var isInvalid = string.IsNullOrWhiteSpace(homework.Title)
                           || string.IsNullOrWhiteSpace(homework.Description)
                           || homework.Link == null;

            if (isInvalid) throw new HomeworkException(HOMEWORK_IS_INVALID);

            var homeworkId = await _homeworksRepository.Update(homework);

            if (homeworkId != default)
            {
                return homeworkId;
            }
            else
            {
                throw new ArgumentNullException(nameof(homeworkId));
            }
        }

        public async Task<Homework> Get(int homeworkId)
        {
            if (homeworkId == default) throw new HomeworkException(HOMEWORK_IS_INVALID);

            var homework = await _homeworksRepository.Get(homeworkId);

            if (homework is not null)
            {
                return homework;
            }
            else
            {
                throw new ArgumentNullException(nameof(homeworkId));
            }
        }

        public async Task<Homework[]> Get()
        {
            var homeworks = await _homeworksRepository.Get();

            if(homeworks.Length != 0 || homeworks is null)
            {
                return homeworks;
            }
            else
            {
                return null;
            }
        }
    }
}
