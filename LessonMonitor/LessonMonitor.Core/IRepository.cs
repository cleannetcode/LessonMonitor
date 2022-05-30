using LessonMonitor.Domain;

namespace LessonMonitor.Core
{
    public interface IUserRepository
    {
        public User Get(string userName);
    }
}
