using System.Threading.Tasks;

namespace LessonMonitor.Core.Services
{
	public interface IHomeworksService
	{
		Task<int> Create(Homework homework);
		Task<bool> Delete(int homeworkId);
	}
}
