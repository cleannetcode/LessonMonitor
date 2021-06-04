namespace LessonMonitor.Core
{
    public interface IHomeworksRepository
    {
        public bool Exists(string username);
    }
}
