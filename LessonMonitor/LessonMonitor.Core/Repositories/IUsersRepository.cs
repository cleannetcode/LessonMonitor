namespace LessonMonitor.Core
{
    public interface IUsersRepository
    {
        void Add(User user);

        User[] Get();
    }
}
