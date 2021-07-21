using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;
using System;
using System.Threading.Tasks;

namespace LessonMonitor.BusinessLogic
{
    public class LessonsService : ILessonsService
    {
        private readonly ILessonsRepository _lessonRepository;

        public LessonsService(ILessonsRepository lessonsRepository)
        {
            _lessonRepository = lessonsRepository;
        }

        public async Task<int> Create(Lesson newlesson)
        {
            if (newlesson is null)
            {
                throw new ArgumentNullException(nameof(newlesson));
            }

            var existingLesson = await _lessonRepository.Get(newlesson.YouTubeBroadcastId);

            if (existingLesson != null)
            {
                throw new InvalidOperationException("Lesson already exists");

            }

            var crearedLessonId = await _lessonRepository.Add(newlesson);

            return crearedLessonId;
        }
    }
}
