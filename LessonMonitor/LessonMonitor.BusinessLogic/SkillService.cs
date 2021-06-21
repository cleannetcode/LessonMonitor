using LessonMonitor.Core;
using LessonMonitor.Core.Models;

namespace LessonMonitor.BusinessLogic
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public Skill GetById(int id)
        {
            return _skillRepository.GetById(id);
        }

        public Skill[] GetAll()
        {
            return _skillRepository.GetAll();
        }

        public Skill Add(Skill skill)
        {
            return _skillRepository.Add(skill);
        }

        public bool Remove(Skill skill)
        {
            return _skillRepository.Remove(skill);
        }
    }
}
