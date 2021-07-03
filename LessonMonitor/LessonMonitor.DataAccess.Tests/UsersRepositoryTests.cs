using System;
using AutoFixture;
using System;
using Xunit;

namespace LessonMonitor.DataAccess.Tests
{
    public class UsersRepositoryTests : IDisposable
    {
        private readonly UsersRepository _repository;

        public UsersRepositoryTests()
        {
            var connection = "Server=localhost;Database=LessonMonitorTestDB;Integrated Security=true;";
            _repository = new UsersRepository(connection);
        }
        
        
        [Fact]
        public void Get()
        {
            var fixture = new Fixture();
            for (int i = 0; i < 10; i++)
            {
                var user = fixture.Create<Core.User>();
                _repository.Create(user);
            }
            //act

            var users = _repository.Get();

            //assert
            
            Assert.NotNull(users);
            Assert.NotEmpty(users);
        }
        
        [Fact]
        public void GetById()
        {
            var fixture = new Fixture();
            var newUser = fixture.Create<Core.User>();
            var id = _repository.Create(newUser);
            
            //act

            var user = _repository.Get(id);

            //assert
            Assert.NotNull(user);
            Assert.Equal(user.Age,newUser.Age);
            Assert.Equal(user.Name,newUser.Name);
        }

        [Fact]
        public void Create()
        {
            var fixture = new Fixture();
            var newUser = fixture.Create<Core.User>();
            
            //act
            var id = _repository.Create(newUser);
            
            //assert
            var user =  _repository.Get(id);
            
            Assert.NotNull(user);
            Assert.Equal(user.Age,newUser.Age);
            Assert.Equal(user.Name,newUser.Name);
        }

        
        [Fact]
        public void Update()
        {
            var fixture = new Fixture();
            var user = fixture.Create<Core.User>();
            
            var updateUser = fixture.Create<Core.User>();
            var id = _repository.Create(user);
            updateUser.Id = id;
            
            //act

            _repository.Update(updateUser);
            //assert
            
            var oldUser = _repository.Get(id);
            
            Assert.NotNull(oldUser);
            Assert.Equal(oldUser.Age,updateUser.Age);
            Assert.Equal(oldUser.Name,updateUser.Name);
            Assert.Equal(oldUser.Id,updateUser.Id);
        }

        
        [Fact]
        public void Delete()
        {
            var fixture = new Fixture();
            var newUser = fixture.Create<Core.User>();
            var id = _repository.Create(newUser);
            
            //act
            
            _repository.Delete(id);
            //assert
            var user =  _repository.Get(id);
            
            Assert.Null(user);
        }
        
        
        public void Dispose()
        {
            _repository.CleanTable();
        }
    }
}