using System;
using System.Threading.Tasks;
using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;

namespace LessonMonitor.BusinessLogic
{
    public class LessonsService : ILessonsService
    {
        private ILessonsRepository _lessonsRepository;

        public LessonsService(ILessonsRepository lessonsRepository)
        {
            _lessonsRepository = lessonsRepository;
        }

        public async Task<int> Create(Lesson newLesson)
        {
            if (newLesson is null)
            {
                throw new ArgumentNullException(nameof(newLesson));
            }

            var existingLesson = await _lessonsRepository.Get(newLesson.YouTubeBroadcastId);

            if (existingLesson != null)
            {
                throw new InvalidOperationException("Lesson already exists");
            }

            var createdLessonId = await _lessonsRepository.Add(newLesson);

            return createdLessonId;
        }
    }
}
