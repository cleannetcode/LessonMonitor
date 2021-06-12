using LessonMonitor.Core;
using LessonMonitor.Core.Exceptions;
using LessonMonitor.Core.Services;
using System;

namespace LessonMonitor.BusinessLogic
{
	public class HomeworksService : IHomeworksService
	{
		public const string HOMEWORK_IS_INVALID = "Homework is invalid!";

		private readonly IHomeworksRepository _homeworksRepository;

		public HomeworksService(IHomeworksRepository homeworksRepository)
		{
			_homeworksRepository = homeworksRepository;
		}

		public bool Create(Homework homework)
		{
			// валидация
			if (homework is null)
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
			_homeworksRepository.Delete(homeworkId);

			return true;
		}
	}
}
