namespace LessonMonitor.Core
{
    public interface IUsersRepository
    {
        void Create(object user);
        object[] Get();
    }
}