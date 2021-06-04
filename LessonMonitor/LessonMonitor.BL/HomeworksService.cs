using LessonMonitor.Core;
using System;

namespace LessonMonitor.BL
{
    public class HomeworksService: IHomeworksService
    {
        private readonly IHomeworksRepository _homeworksRepository;

        public HomeworksService(IHomeworksRepository homeworksRepository)
        {
            _homeworksRepository = homeworksRepository;
        }

        public bool Exists(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException(nameof(username));

            return _homeworksRepository.Exists(username);
        }
    }
}
