using LessonMonitor.Core;

namespace LessonMonitor.Core
{
    public interface IGitHubService
    {
        UserCore[] GetRepository();
        void CreateRepository(UserCore user);
        bool ChangeRepositoryName(string nameRep, string newName);
        void DeleteRepository(UserCore user);
    }
}