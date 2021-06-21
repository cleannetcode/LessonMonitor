using LessonMonitor.Core.Models;

namespace LessonMonitor.Core
{
    public interface ISkillRepository
    {
        Skill Add(Skill skill);
        Skill[] GetAll();
        Skill GetById(int id);
        bool Remove(Skill skill);
    }
}