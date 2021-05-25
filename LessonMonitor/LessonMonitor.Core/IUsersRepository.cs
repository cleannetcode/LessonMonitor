using LessonMonitor.Core.Models;

namespace LessonMonitor.Core
{
    public interface IUsersRepository
    {
        void Create(User user);
        User[] Get();
    }
}