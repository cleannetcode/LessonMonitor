namespace LessonMonitor.Core.Repositories
{
    public interface IUsersRepository
    {
        void Create(User user);
        User[] Get();
    }
}