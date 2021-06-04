using LessonMonitor.Core.Models;

namespace LessonMonitor.Core
{
    public interface IUsersRepository
    {
        void Add(User user);
        User GetByName(string name);
    }
}
