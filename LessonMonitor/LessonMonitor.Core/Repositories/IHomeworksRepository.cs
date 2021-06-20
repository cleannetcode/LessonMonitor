namespace LessonMonitor.Core
{
	public interface IHomeworksRepository
	{
		int Add(Homework newHomework);
		void Update(Homework homework);
		void Delete(int homeworkId);
		Homework[] Get();
		Homework Get(int homeworkId);
	}
}
