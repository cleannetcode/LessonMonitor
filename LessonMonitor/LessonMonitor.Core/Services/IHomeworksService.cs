namespace LessonMonitor.Core.Services
{
	public interface IHomeworksService
	{
		bool Create(Homework homework);
		bool Delete(int homeworkId);
	}
}
