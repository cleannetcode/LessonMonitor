using System.Threading.Tasks;

namespace LessonMonitor.Core
{
	public interface IHomeworksRepository
	{
		Task<int> Add(Homework newHomework);
		Task Update(Homework homework);
		Task Delete(int homeworkId);
		Task<Homework[]> Get();
		Task<Homework> Get(int homeworkId);
	}
}
