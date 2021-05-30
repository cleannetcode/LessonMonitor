using LessonMonitor.Core;

namespace LessonMonitor.BusinessLogic
{
	public class UsersService : IUsersService
	{
		private readonly IUsersRepository _usersRepository;

		private readonly GithubClient _githubClient;

		public UsersService(IUsersRepository usersRepository,
			GithubClient githubClient)
		{
			_usersRepository = usersRepository;
			_githubClient = githubClient;
		}

		public User[] Get()
		{
			var users = _usersRepository.Get();

			var githubUser = _githubClient.Get("nickname");

			return users;
		}

		public void Create(User user)
		{

		}
	}

	public class GithubClient
	{
		public GithubUser Get(string nickname)
		{
			return new GithubUser();
		}
	}

	public class GithubUser
	{

	}
}
