namespace LessonMonitor.Core
{
    public interface IUserService
    {
        void Create(object user);
        User[] Get();
    }
}