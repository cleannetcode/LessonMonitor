using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson1.ASP.NET.Models;

namespace Lesson1.ASP.NET.Interfaces
{
    public interface IRepositoryDb
    {
        /// <summary>
        /// Метод создания сущности в базе.
        /// </summary>
        /// <typeparam name="T">Нужный класс.</typeparam>
        /// <param name="model"></param>
        void Create<T>(T model) where T : class;

        /// <summary>
        /// Метод удаления сущности из базы.
        /// </summary>
        /// <typeparam name="T">Нужный класс.</typeparam>
        /// <param name="id">id объекта в базе.</param>
        /// <returns>true - объект удален, false - ошибка удаления</returns>
        bool Delete<T>(int id) where T : class;

        /// <summary>
        /// Метод изменения сущности в базе.
        /// </summary>
        /// <typeparam name="T">Нужный класс.</typeparam>
        /// <param name="model">Сущность для изменения.</param>
        /// <returns>true - объект изменен, false - ошибка изменения</returns>
        bool Edit<T>(T model) where T : class;


        /// <summary>
        /// Возвращает коллекцию объектов из базы.
        /// </summary>
        /// <typeparam name="T">Нужный класс.</typeparam>
        /// <returns>Коллекция объектов.</returns>
        List<T> GetCollectionModel<T>();
    }
}
