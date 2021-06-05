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
                    Nicknames = f.Nicknames,
                    Email = f.Email,
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
                Nicknames = user.Nicknames,
                Email = user.Email,
                CreatedDate = DateTime.Now
            };

            _context.Users.Add(newUser);

            _context.SaveChanges();
        }
    }
}
