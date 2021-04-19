using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Lesson1.ASP.NET.Interfaces
{
    public interface IRepositoryDb
    {
        /// <summary>
        /// The method for creating an entity in the database.
        /// </summary>
        /// <typeparam name="T">The right class.</typeparam>
        /// <param name="model"></param>
        /// <returns>true - object created, false - creation error</returns>
        bool Create<T>(T model) where T : class;

        /// <summary>
        /// The method for removing an entity from the database.
        /// </summary>
        /// <typeparam name="T">The right class.</typeparam>
        /// <param name="id">id of the object in the database.</param>
        /// <returns>true - object was deleted, false - error of deletion</returns>
        bool Delete<T>(int id) where T : class;

        /// <summary>
        /// The method for changing an entity in the database.
        /// </summary>
        /// <typeparam name="T">The right class.</typeparam>
        /// <param name="model">Entity to change.</param>
        /// <returns>true - object changed, false - change error</returns>
        bool Edit<T>(T model) where T : class;


        /// <summary>
        /// Returns a collection of objects from the base.
        /// </summary>
        /// <typeparam name="T">The right class.</typeparam>
        /// <returns>A collection of objects.</returns>
        List<T> GetCollectionModel<T>();


        /// <summary>
        /// The method returns an object from the collection.
        /// </summary>
        /// <typeparam name="T">The right class.</typeparam>
        /// <param name="id">id of the object in the database.</param>
        /// <returns>Object.</returns>
        T GetOneObject<T>(int id) where T : class;
    }
}
