using LessonMonitor.Core.Repositories;
using System;

namespace LessonMonitor.DataAccess.Repositories
{
    public class HomeworkRepository : IHomeworksRepository
    {
        private string _connectionString;
        public HomeworkRepository() {}

        public void Add(Core.Homework homework)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid homeworkId)
        {
            throw new NotImplementedException();
        }

        public Core.Homework Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(Core.Homework homework)
        {
            throw new NotImplementedException();
        }
    }
}
