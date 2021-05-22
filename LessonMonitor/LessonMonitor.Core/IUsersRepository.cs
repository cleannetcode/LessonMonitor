namespace LessonMonitor.Core
{
	public interface IUsersRepository
	{
		void Create(User user);
		User[] Get();
	}
}
