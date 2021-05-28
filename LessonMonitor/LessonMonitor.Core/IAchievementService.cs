namespace LessonMonitor.Core
{
    public interface IAchievementService
    {
        void Create(Achievement achievement);
        Achievement GetFirst();
    }
}
