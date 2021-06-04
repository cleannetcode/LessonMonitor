using LessonMonitor.Core;
using LessonMonitor.Core.Models;

namespace LessonMonitor.DAL
{
    public class UserCacheRepository : IUsersRepository
    {
        private readonly IUsersRepository _repository;

        public UserCacheRepository(UsersRepository repository, ICacheManager cacheManager)
        {
            this._repository = repository;
        }

        public void Add(User user)
        {
            throw new System.NotImplementedException();
        }

        public User GetByName(string name)
        {
            return _repository.GetByName(name);
        }
    }
}
