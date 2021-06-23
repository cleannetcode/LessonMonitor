using LessonMonitor.Core.CoreModels;

namespace LessonMonitor.Core.Services
{
    public interface IUsersService
    {
        bool Create(User user);
        User[] Get();

        bool Update(User user);
    }
}