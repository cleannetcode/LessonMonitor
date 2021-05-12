using LessonMonitor.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.Api
{
    public class InMemorySkillRepository : ISkillRepository
    {
        private readonly Skill[] skills;

        public InMemorySkillRepository()
        {
            // roadmap = https://bool.dev/blog/detail/dotnetcore-developer-roadmap
            skills = new Skill[]
            {
                new Skill{ Id = 1, ParentId = 0, SkillName = "C#"},
                new Skill{ Id = 2, ParentId = 1, SkillName = "Learn the basics of C#"},
                new Skill{ Id = 3, ParentId = 1, SkillName = "Learn LINQ"},

                new Skill{ Id = 4, ParentId = 0, SkillName = "ASP.NET Core Basics"},
                new Skill{ Id = 5, ParentId = 4, SkillName = "MVC"},
                new Skill{ Id = 6, ParentId = 4, SkillName = "REST"},
                new Skill{ Id = 7, ParentId = 4, SkillName = "Razor Pages"},
                new Skill{ Id = 8, ParentId = 4, SkillName = "Razor Components"},
                new Skill{ Id = 9, ParentId = 4, SkillName = "Middlewares"},
                new Skill{ Id = 10, ParentId = 4, SkillName = "Filters & Attributes"},
                new Skill{ Id = 11, ParentId = 4, SkillName = "Application Settings & Configurations"},
            };
        }

        public Skill[] GetAll()
        {
            return skills;
        }

        public Skill GetById(int id)
        {
            return skills.Where(s => s.Id == id).FirstOrDefault();
        }
    }
}
