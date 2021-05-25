using LessonMonitor.Core;
using LessonMonitor.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return new Core.Skill
            {
                Id = foundSkill.Id,
                Title = foundSkill.Title,
                ParentId = foundSkill.ParentId
            };
        }

        public Skill[] GetAll()
        {
            return skills.Select(s=> new Core.Skill()
            {
                Id = s.Id,
                Title = s.Title,
                ParentId = s.ParentId
            }).ToArray();
        }

        // Не нравится реализация данного метода.
        // Может быть нужно было использоваться какой то DTO без поля id, который принимает данный метод?
        // Здесь я не могу использовать SkillEntity т.к. интерфейс ISkillRepository расположен в LessonMonitor.Core
        // и у данного проект установлена зависимость на LessonMonitor.Core
        // Добавить зависимость в LessonMonitor.Core на LessonMonitor.DataAccess.InMemory нельзя т.к. возникает ошибка
        /*
        ---------------------------
        Microsoft Visual Studio
        ---------------------------
        A reference to 'LessonMonitor.DataAccess.InMemory' could not be added. Adding this project as a reference would cause a circular dependency.
        ---------------------------
        ОК   
        ---------------------------
         */
        // в связи с этим вопрос: вообще правильно ли так делать? или что то я не понимаю и надо ещё понять
        // Может быть надо DTO положить в какой то отдельный слой? Для чего это будет нужно?
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
