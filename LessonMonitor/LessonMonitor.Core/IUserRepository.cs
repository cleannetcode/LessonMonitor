namespace LessonMonitor.Core
{
    public interface IUserRepository
    {
        void Create(UserCore user);
        UserCore[] Get();
    }
}