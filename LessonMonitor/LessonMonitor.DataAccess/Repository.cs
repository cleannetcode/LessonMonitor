using LessonMonitor.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LessonMonitor.DataAccess
{
    public class Repository<T> : IRepository<T> where T : LessonMonitor.Core.Models.BaseEntity
    {
        private readonly ApplicationContext context;
        private readonly DbSet<T> entities;
        public Repository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T Get(int id)
        {
            return entities.SingleOrDefault(p => p.Id == id);
        }
    }
}
