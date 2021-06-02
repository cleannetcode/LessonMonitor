namespace LessonMonitor.Core
{
    public interface IAchievementRepository
    {
        void Create(Achievement achievement);
        Achievement GetFirst();
    }
}
