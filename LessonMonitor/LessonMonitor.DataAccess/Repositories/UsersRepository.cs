using LessonMonitor.Core.Repositories;
using System;
using System.Linq;

namespace LessonMonitor.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public UsersRepository() {}

        public Core.User[] Get()
        {
            using SqlDbContext _context = new SqlDbContext();


            return _context.Users.Select(f =>
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

        public void Add(Core.User user)
        {
            using SqlDbContext _context = new SqlDbContext();


            var newUser = new Entites.User
            {
                Id = user.Id,
                Name = user.Name,
                Nicknames = user.Nicknames,
                Email = user.Email,
                CreatedDate = DateTime.Now
            };

            _context.Users.Add(newUser);

            _context.SaveChanges();
        }

        public bool Update(Core.User user)
        {
            throw new NotImplementedException();
        }
    }
}
