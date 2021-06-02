using LessonMonitor.Domain.Models.BusinessLogic;

namespace LessonMonitor.Domain.Interfaces.BisinessLogic
{
    public interface IUsersService
    {
        public UserBusinessLayer[] GetAllUsers();
        public UserBusinessLayer GetUserById(int id);
        public bool CreateNewUser(UserBusinessLayer user);
    }
}