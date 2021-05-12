using LessonMonitor.Api.Models;

namespace LessonMonitor.Api
{
    public interface ISkillRepository
    {
        Skill[] GetAll();
        Skill GetById(int id);
    }
}