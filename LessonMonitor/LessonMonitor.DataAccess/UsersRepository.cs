using LessonMonitor.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LessonMonitor.DataAccess
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDbContextFactory<SqlDbContext> _contextFactory;
        public UsersRepository()
        {
            
        }

        public Core.User[] Get()
        {
            using var context = _contextFactory.CreateDbContext();

                return context.Users.Select(f =>
                    new Core.User()
                    {
                        Id = f.Id,
                        Name = f.Name,
                        Nicknames = f.Nicknames,
                        Email = f.Email,
                        CreatedDate = f.CreatedDate
                    }
                    ).ToArray();
        }

        public void Create(Core.User user)
        {
            using var context = _contextFactory.CreateDbContext();

            var newUser = new DataAccess.User
            {
                Id = user.Id,
                Name = user.Name,
                Nicknames = user.Nicknames,
                Email = user.Email,
                CreatedDate = DateTime.Now
            };

            context.Users.Add(newUser);

            context.SaveChanges();
        }
    }
}
