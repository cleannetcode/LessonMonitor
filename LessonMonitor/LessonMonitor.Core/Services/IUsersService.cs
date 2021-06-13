namespace LessonMonitor.Core.Services
{
    public interface IUsersService
    {
        void Create(User user);
        User[] Get();
    }
}