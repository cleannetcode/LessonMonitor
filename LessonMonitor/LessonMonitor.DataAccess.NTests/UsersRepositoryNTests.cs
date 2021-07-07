using AutoFixture;
using LessonMonitor.Core.CoreModels;
using NUnit.Framework;
using System.Collections.Generic;

namespace LessonMonitor.DataAccess.NTests
{
    public class UsersRepositoryNTests
	{
  //      private UsersRepository _repository;
  //      public UsersRepositoryNTests() { }

  //      [SetUp]
  //      public void SetUp()
  //      {
		//	var connectionString = @"Data Source=ASHTON\ASHTON;Initial Catalog=LessonMonitorTestDb;Integrated Security=True;";

		//	_repository = new UsersRepository(connectionString);
		//}

		//[Test]
		//public void Add_ValidUser_ShouldCreateNewUser()
		//{
		//	// arrange
		//	var fixture = new Fixture();
		//	var user = fixture.Build<User>().Create();

		//	// act
		//	var createdUserId = _repository.Add(user);

		//	// assert
		//	Assert.True(createdUserId > 20);
		//}

		//[Test]
		//public void Update()
		//{
		//	// arrange
		//	var fixture = new Fixture();
		//	var newUser = fixture.Build<User>().Create();
		//	var userId = _repository.Add(newUser);
		//	var updatedUser = fixture.Build<User>().Create();
		//	updatedUser.Id = userId;

		//	// act
		//	_repository.Update(updatedUser);

		//	// assert
		//	var user = _repository.Get(userId);

		//	Assert.NotNull(user);
		//	Assert.AreEqual(updatedUser.Id, user.Id);
		//	Assert.AreEqual(updatedUser.Name, user.Name);
		//	Assert.AreEqual(updatedUser.Nicknames, user.Nicknames);
		//	Assert.AreEqual(updatedUser.Email, user.Email);
		//}

		//[Test]
		//public void Get()
		//{
		//	// arrange
		//	var fixture = new Fixture();

		//	for (int i = 0; i < 10; i++)
		//	{
		//		var user = fixture.Build<User>().Create();

		//		_repository.Add(user);
		//	}

		//	// act
		//	var users = _repository.Get();

		//	// assert
		//	Assert.NotNull(users);
		//	Assert.IsNotEmpty(users);
		//}

		//[Test]
		//public void GetWithUserId()
		//{
		//	var fixture = new Fixture();
		//	var newUser = fixture.Build<User>().Create();
		//	var userId = _repository.Add(newUser);

		//	// act
		//	var user = _repository.Get(userId);

		//	// assert
		//	Assert.NotNull(user);
		//}

		//[Test]
		//public void Delete()
		//{
		//	var fixture = new Fixture();
		//	var newUser = fixture.Build<User>().Create();
		//	var userId = _repository.Add(newUser);

		//	// act
		//	_repository.Delete(userId);

		//	// assert
		//	var user = _repository.Get(userId);

		//	Assert.Null(user);
		//}

		//[TearDown]
		//public void DeleteTestData()
		//{
		//	_repository.CleanTable();
		//}
	}
}
