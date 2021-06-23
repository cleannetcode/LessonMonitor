using LessonMonitor.Core.CoreModels;

namespace LessonMonitor.Core.Repositories
{
    public interface IUsersRepository
    {
        int Add(User newUser);
        void Delete(int userId);
        User Get(int userId);
        User[] Get();
        void Update(User user);
    }
}