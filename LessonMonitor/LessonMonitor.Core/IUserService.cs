using LessonMonitor.Core.Models;

namespace LessonMonitor.Core
{
    public interface IUserService
    {
        void Create(object user);
        User[] Get();
    }
}