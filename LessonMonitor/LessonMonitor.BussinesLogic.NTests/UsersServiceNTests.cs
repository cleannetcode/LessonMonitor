using AutoFixture;
using FluentAssertions;
using LessonMonitor.Core.CoreModels;
using LessonMonitor.Core.Exceprions;
using LessonMonitor.Core.Repositories;
using Moq;
using NUnit.Framework;
using System;

namespace LessonMonitor.BussinesLogic.NTests
{
    public class UsersServiceNTests
    {
        private Mock<IUsersRepository> _usersRepositoryMock;
        private UsersService _service;

        public UsersServiceNTests() { }

        [SetUp]
        public void SetUp()
        {
            _usersRepositoryMock = new Mock<IUsersRepository>();
            _service = new UsersService(_usersRepositoryMock.Object);
        }

        [Test]
        public void Create_UserIsValide_ShouldCreateNewUser()
        {
            // arrange - подготавливаем данные
            var fixture = new Fixture();

            var user = fixture.Build<User>()
                .Create();

            // act - запускаем тестируемый метод
            var result = _service.Create(user);

            // assert - проверяем/валидируем результаты теста
            result.Should().BeTrue();
            _usersRepositoryMock.Verify(x => x.Add(user), Times.Once);
        }

        [Test]
        public void Create_UserIsNull_ShouldThrowBusinessExceprion()
        {
            // arrange 
            User user = null;

            // act 
            bool result = false;

            var exceprtion = Assert.Throws<ArgumentNullException>(() => result = _service.Create(user));

            // assert
            exceprtion.Should().NotBeNull()
                .And.Match<ArgumentNullException>(x => x.ParamName == "user");

            result.Should().BeFalse();
            _usersRepositoryMock.Verify(x => x.Add(user), Times.Never);
        }

        [TestCase(0)]
        [TestCase(-236)]
        [TestCase(-53236)]
        [TestCase(-742364366)]
        public void Create_UserIsInvalide_ShouldThrowBusinessExceprion(int userId)
        {
            // arrange
            var fixture = new Fixture();

            var user = fixture.Build<User>()
                .Without(x => x.Name)
                .Without(x => x.Nicknames)
                .Create();

            user.Id = userId;

            // act
            bool result = false;

            var exceprtion = Assert.Throws<UserException>(() => result = _service.Create(user));

            // assert
            exceprtion.Should().NotBeNull()
              .And
              .Match<UserException>(x => x.Message == UsersService.USER_IS_INVALID);

            result.Should().BeFalse();
            _usersRepositoryMock.Verify(x => x.Add(user), Times.Never);
        }

        
        [Test]
        public void Update_UserIsValide_ShouldUpdateUser()
        {
            // arrange - подготавливаем данные
            var fixture = new Fixture();

            var user = fixture.Build<User>().Create();

            // act - запускаем тестируемый метод
            var result = _service.Update(user);

            // assert - проверяем/валидируем результаты теста
            result.Should().BeTrue();
            _usersRepositoryMock.Verify(x => x.Update(user), Times.Once);
        }

        [TestCase(0)]
        [TestCase(-236)]
        [TestCase(-53236)]
        [TestCase(-742364366)]
        public void Update_UserIsInvalide_ShouldThrowBusinessExceprion(int userId)
        {
            // arrange - подготавливаем данные
            var fixture = new Fixture();

            var user = fixture.Build<User>()
                .Without(x => x.Name)
                .Without(x => x.Nicknames)
                .Create();

            user.Id = userId;

            // act
            bool result = false;

            var exceprtion = Assert.Throws<UserException>(() => result = _service.Update(user));

            // assert
            exceprtion.Should().NotBeNull()
              .And
              .Match<UserException>(x => x.Message == UsersService.USER_IS_INVALID);

            result.Should().BeFalse();
            _usersRepositoryMock.Verify(x => x.Update(user), Times.Never);
        }

        [Test]
        public void Update_UserIsINull_ShouldThrowBusinessExceprion()
        {
            // arrange 
            User user = null;

            // act 
            bool result = false;

            var exceprtion = Assert.Throws<ArgumentNullException>(() => result = _service.Update(user));

            // assert
            exceprtion.Should().NotBeNull()
                .And.Match<ArgumentNullException>(x => x.ParamName == "user");

            result.Should().BeFalse();
            _usersRepositoryMock.Verify(x => x.Update(user), Times.Never);
        }
    }
}
