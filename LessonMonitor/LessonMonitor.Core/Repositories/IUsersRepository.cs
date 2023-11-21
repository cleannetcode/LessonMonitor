using LessonMonitor.Core.Models;

namespace LessonMonitor.Core.Repositories
{
    public interface IUsersRepository
    {
        void Create(User user);
        User[] Get();
    }
}
