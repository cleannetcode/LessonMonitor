using LessonMonitor.Core;

namespace LessonMonitor.BusinessLogic
{
    public class AchievementService : IAchievementService
    {
        private readonly IAchievementRepository _achievementRepository;
        public AchievementService(IAchievementRepository achievementRepository)
        {
            _achievementRepository = achievementRepository;
        }
        public void Create(Achievement achievement)
        {
            _achievementRepository.Create(achievement);
        }

        public Achievement GetFirst()
        {
            var achievements = _achievementRepository.GetFirst();
            return achievements;
        }
    }
}
