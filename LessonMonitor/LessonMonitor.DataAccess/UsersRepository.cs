using LessonMonitor.Core;
using System;
using System.Linq;

namespace LessonMonitor.DataAccess
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
                    Email = f.Email,
                    Nicknames = f.Nicknames,
                    CreatedDate = f.CreatedDate
                }
                ).ToArray();
        }

        public void Create(Core.User user)
        {
            using SqlDbContext _context = new SqlDbContext();

            var newUser = new DataAccess.User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CreatedDate = DateTime.Now
            };

            _context.Users.Add(newUser);

            _context.SaveChanges();
        }
    }
}
