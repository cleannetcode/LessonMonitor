namespace LessonMonitor.Core.Repository
{
	public interface IUsersRepository
	{
		void Create(User user);
		User[] Get();
	}
}
