using Microsoft.AspNetCore.Mvc;
using System;
using LessonMonitor.BusinessLogic;
using LessonMonitor.Core;
using LessonMonitor.DataAccess;

namespace LessonMonitor.API.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly IUsersService _userService;

		public UsersController()
		{
			IUsersRepository usersRepository = new UsersRepository();
			UsersService _userService = new UsersService(usersRepository, null);
		}

		[HttpGet]
		public Contracts.User[] Get(string userName)
		{
			var user = _userService.Get();

			var result = new Contracts.User();

			return new[] { result };
		}

		[HttpPost]
		public Contracts.User Create(Contracts.User newUser)
		{
			var user = new Core.User
			{
				Age = newUser.Age,
				Name = newUser.Name
			};

			_userService.Create(user);

			return newUser;
		}

		[HttpGet("model")]
		public void GetModel([FromQuery] Contracts.User user)
		{
			var model = user.GetType();

			foreach (var propetry in model.GetProperties())
			{
				foreach (var customAttribute in propetry.CustomAttributes)
				{
					if (customAttribute.AttributeType.Name == "RequiredAttribute")
					{
						var value = propetry.GetValue(user);
						var specifiedValue = Convert.ChangeType(value, propetry.PropertyType);

						if (value is DateTime dateValue && dateValue == default(DateTime))
						{
							throw new Exception($"{propetry.Name}: {value}");
						}

						if (value is int intValue && intValue == default(int))
						{
							throw new Exception($"{propetry.Name}: {value}");
						}

						if (value == null)
						{
							throw new Exception($"{propetry.Name}: {value}");
						}
					}
				}
			}
		}
	}
}
