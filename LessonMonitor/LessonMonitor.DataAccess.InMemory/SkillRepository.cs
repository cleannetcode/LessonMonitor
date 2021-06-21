using LessonMonitor.Core;
using LessonMonitor.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace LessonMonitor.DataAccess.InMemory
{
    public class SkillRepository : ISkillRepository
    {
        private readonly List<SkillEntity> skills;

        public SkillRepository()
        {
            skills = new List<SkillEntity>()
            {
                new SkillEntity{ Id = 1, ParentId = 0, Title = "C#"},
                new SkillEntity{ Id = 2, ParentId = 1, Title = "Learn the basics of C#"},
                new SkillEntity{ Id = 3, ParentId = 1, Title = "Learn LINQ"},

                new SkillEntity{ Id = 4, ParentId = 0, Title = "ASP.NET Core Basics"},
                new SkillEntity{ Id = 5, ParentId = 4, Title = "MVC"},
                new SkillEntity{ Id = 6, ParentId = 4, Title = "REST"},
                new SkillEntity{ Id = 7, ParentId = 4, Title = "Razor Pages"},
                new SkillEntity{ Id = 8, ParentId = 4, Title = "Razor Components"},
                new SkillEntity{ Id = 9, ParentId = 4, Title = "Middlewares"},
                new SkillEntity{ Id = 10, ParentId = 4, Title = "Filters & Attributes"},
                new SkillEntity{ Id = 11, ParentId = 4, Title = "Application Settings & Configurations"},
            };
        }

        public Skill GetById(int id)
        {
            var foundSkill = skills.Where(s => s.Id == id).FirstOrDefault();

            if (foundSkill == null)
                return null;

            return new Core.Models.Skill
            {
                Id = foundSkill.Id,
                Title = foundSkill.Title,
                ParentId = foundSkill.ParentId
            };
        }

        public Skill[] GetAll()
        {
            return skills.Select(s=> new Core.Models.Skill()
            {
                Id = s.Id,
                Title = s.Title,
                ParentId = s.ParentId
            }).ToArray();
        }

        public Skill Add(Skill skill)
        {
            int nextId = skills.Max(s => s.Id) + 1;
            skill.Id = nextId;

            SkillEntity skillEntity = new SkillEntity()
            {
                Id = skill.Id,
                Title = skill.Title,
                ParentId = skill.ParentId
            };

            skills.Add(skillEntity);

            return skill;
        }

        public bool Remove(Skill skill)
        {
            return skills.Remove(new SkillEntity()
            {
                Id = skill.Id,
                Title = skill.Title,
                ParentId = skill.ParentId
            });
        }
    }
}
