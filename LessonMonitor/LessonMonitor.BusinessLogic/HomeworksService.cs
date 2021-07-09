using LessonMonitor.Core;
using LessonMonitor.Core.Exceptions;
using LessonMonitor.Core.Services;
using System;
using System.Threading.Tasks;

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

		public async Task<int> Create(Homework homework)
		{
			// валидация
			if (homework is null)
			{
				throw new ArgumentNullException(nameof(homework));
			}

			var isInvalid = homework.Link == null
				|| string.IsNullOrWhiteSpace(homework.Title);

			if (isInvalid)
			{
				throw new BusinessException(HOMEWORK_IS_INVALID);
			}

			var homeworkId = await _homeworksRepository.Add(homework);

			return homeworkId;
		}

		public async Task<bool> Delete(int homeworkId)
		{
			if (homeworkId == default)
				throw new ArgumentException(nameof(homeworkId));

			await _homeworksRepository.Delete(homeworkId);

			return true;
		}
	}
}
