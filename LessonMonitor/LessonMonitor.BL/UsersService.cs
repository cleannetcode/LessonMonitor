using LessonMonitor.Core.Models;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;

namespace LessonMonitor.BL
{
    public class UsersService : IUsersService
	{
		private IUsersRepository _usersRepository;

		public UsersService(IUsersRepository usersRepository)
		{
			_usersRepository = usersRepository;
		}

		public User[] Get()
		{
			var users = _usersRepository.Get();

			return users;
		}

		public void Create(User user)
		{

		}
	}


}
