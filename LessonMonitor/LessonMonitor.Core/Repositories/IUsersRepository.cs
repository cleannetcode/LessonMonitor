namespace LessonMonitor.Core
{
	public interface IUsersRepository
	{
		int Create(User user);
		User[] Get();
		User Get(int userId);
		void Update(User user);
		void Delete(int userId);
	}
}
