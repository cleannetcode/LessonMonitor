namespace LessonMonitor.Core.Service
{
	public interface IUsersService
	{
		void Create(User user);
		User[] Get();
	}
}
