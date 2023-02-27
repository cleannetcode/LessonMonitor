using LessonMonitor.Core.Exceptions;
using LessonMonitor.Core.Models;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace LessonMonitor.BL
{
    public class HomeworkService : IHomeworkService
    {
        public const string HOMEWORK_IS_INVALID = "Homework is invalid";
        private readonly IHomeworkRepository _homeworkRepository;

        public HomeworkService(IHomeworkRepository homeworkRepository)
        {
            _homeworkRepository = homeworkRepository;
        }

        public object Create(Homework homework)
        {
            if (homework == null)
            {
                throw new ArgumentNullException(nameof(homework));
            }

            bool isInvalid = string.IsNullOrWhiteSpace(homework.Title)
                || string.IsNullOrWhiteSpace(homework.Link)
                || homework.MemberId <= 0;

            if (isInvalid)
            {
                throw new BusinessException(HOMEWORK_IS_INVALID);
            }
            _homeworkRepository.Add(homework);
            return new object();
        }

        public bool Delete(int homeworkId)
        {
            var ok = _homeworkRepository.Delete(homeworkId);
            return true;
        }
    }
}
