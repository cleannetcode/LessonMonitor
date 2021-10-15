using LessonMonitor.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonMonitor.Data
{
    public class UserRepository : IUserRepository, IGitHubRepository
    {
        private UserCore[] users;
        public UserRepository()
        {
            users = GetRepository();
        }
        public UserCore[] GetRepository()
        {
            var user = new UserData { Id = 1, Age = 41, Name = "Alex", Link = "https://github.com/Alex/Test_repos", RepositoryName = "Test Repository" };

            return new[]
            {
                new UserCore
                {
                    Age=user.Age, Name = user.Name, Link = user.Link, RepositoryName = user.RepositoryName
                }
            };
        }
        public bool ChangeRepositoryName(string nameRep, string newName)
        {
            var userData = users;
            foreach (var item in userData)
            {
                if (item.RepositoryName == nameRep )
                {
                    item.RepositoryName = newName;
                    return true;
                }         
            }
            return false;
        }


        public void CreateRepository(UserCore user)
        {
            var userData = new UserData();
            userData.Id = 0;
            userData.Name = user.Name;
            userData.Age = user.Age;
            userData.Link = user.Link;
            user.RepositoryName = user.RepositoryName;
        }

        public void DeleteRepository(UserCore user)
        {
            throw new NotImplementedException();
        }

        public UserCore[] Get()
        {
            var user = new UserData
            {
                Id = 1,
                Age = 31,
                Name = "Alex"
            };
            return new[]
            {
                new UserCore
                {
                    Age = user.Age,
                    Name = user.Name
                }
            };
        }

        public void Create(UserCore user)
        {
            Console.WriteLine($"{user.Name} - {user.Age}");
        }


    }
}
