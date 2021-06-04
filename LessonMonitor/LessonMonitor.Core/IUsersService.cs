using LessonMonitor.Core.Models;

namespace LessonMonitor.Core
{
    public interface IUsersService
    {
        void Create(User user);
        User GetByName(string name);
    }
}
