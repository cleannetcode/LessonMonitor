using LessonMonitor.Core;
using LessonMonitor.Domain;

namespace LessonMonitor.BL
{
    public class UserCacheRepository : IUserRepository
    {
        private readonly IUserRepository repository;

        public UserCacheRepository(UserRespository repository, ICacheManager cacheManager)
        {
            this.repository = repository;
        }

        public User Get(string userName)
        {
            // get from cache 
            // if null  var user = IUserRepository.Get(userName);
            //          save user into cache
            // else return user

            return repository.Get(userName);
        }
    }
}