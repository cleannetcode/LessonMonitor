using LessonMonitor.Core.CoreModels;

namespace LessonMonitor.Core.Repositories
{
    public interface IUsersRepository
    {
        void Add(User user);
        User[] Get();

        bool Update(User user);
    }
}