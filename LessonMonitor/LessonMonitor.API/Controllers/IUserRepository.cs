namespace LessonMonitor.API.Controllers
{
    public interface IUserRepository
    {
        public User Get(string userName);
    }
}