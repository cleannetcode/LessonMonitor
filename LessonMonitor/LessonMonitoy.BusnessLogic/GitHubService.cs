using LessonMonitor.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonMonitor.BusnessLogic
{
    public class GitHubService : IGitHubService
    {
        IGitHubRepository _gitHubRepository;
        public GitHubService(IGitHubRepository gitHub)
        {
            _gitHubRepository = gitHub;
        }
        public bool ChangeRepositoryName(string nameRer, string newName)
        {
           return _gitHubRepository.ChangeRepositoryName(nameRer, newName);
        }

        public void CreateRepository(UserCore user)
        {
            _gitHubRepository.CreateRepository(user);
        }

        public void DeleteRepository(UserCore user)
        {
            throw new NotImplementedException();
        }

        public UserCore[] GetRepository()
        {
            return _gitHubRepository.GetRepository();
        }
    }
}
