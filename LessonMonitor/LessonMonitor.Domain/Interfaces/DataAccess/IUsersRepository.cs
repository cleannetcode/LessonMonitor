using LessonMonitor.Domain.Models.DataAccess;

namespace LessonMonitor.Domain.Interfaces.DataAccess
{
    public interface IUsersRepository
    {
        public UserDataLayer[] GetAllUsers();
        public UserDataLayer GetUserById(int id);
        public bool CreateNewUser(UserDataLayer user);
    }
}