using SR.Bertoni.Test.Depency;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Forms;
using SR.Bertoni.Test.Repository.Tasks;

namespace SR.Bertoni.Test.Repository
{
    public class Database
    {
        string _databasePath;
        public const string DATA_FOLDER = "Data";
        public const string DATABASE_NAME = "tasks.sqlite";

        public SQLiteConnection Connection { get; set; }

        public void Open()
        {
            try
            {
                var directoryname = DependencyService.Get<IFileHelper>().GetDatabasePath();

                _databasePath = Path.Combine(directoryname, DATABASE_NAME);

                Connection = new SQLiteConnection(_databasePath,
                                                  SQLiteOpenFlags.ReadWrite |
                                                  SQLiteOpenFlags.Create |
                                                  SQLiteOpenFlags.FullMutex, false);
                Connection.CreateTable<TaskTable>();
                //
            }
            catch (Exception ex)
            {

            }
        }

        #region Extended Methods

        /// <summary>
        /// Insert an object to the database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">T object to insert</param>
        public void Insert<T>(T entity) where T : TableModel
        {
            try
            {
                Connection.Insert(entity);
            }
            catch (Exception ex)
            {
            }
        }

        public void InsertAll<T>(List<T> entityList) where T : TableModel
        {
            try
            {
                foreach (var item in entityList)
                {
                    Connection.Insert(item);
                }
            }
            catch (Exception ex)
            {
                //nothing
            }
        }

        public void StartTransaction()
        {
            Connection.BeginTransaction();
        }

        public void EndTransaction()
        {
            Connection.Commit();
        }

        /// <summary>
        /// Update the object in the database.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="entity">Object to update.</param>
        public void Update<T>(T entity) where T : TableModel
        {
            try
            {
                Connection.Update(entity);
            }
            catch (Exception ex)
            {
            }
        }

        public void TruncateTable<T>() where T : TableModel
        {
            Connection.DeleteAll<T>();
        }

        public void DeleteObject<T>(object Id)
        {
            //lock (this)
            {
                Connection.Delete<T>(Id);
            }
        }
        #endregion
    }
}
