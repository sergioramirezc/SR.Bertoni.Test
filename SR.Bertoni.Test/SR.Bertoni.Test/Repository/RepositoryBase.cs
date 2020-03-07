using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Bertoni.Test.Repository
{
    public class RepositoryBase<T> where T : TableModel, new()
    {
        protected readonly DataLayer _dataLayer;

        public RepositoryBase()
        {
            _dataLayer = DataLayer.Instance;
        }

        public virtual async Task<List<T>> GetAll()
        {
            var localList = new List<T>();

            try
            {
                localList = await Task.Run(() => _dataLayer.Database.Connection.Table<T>()
                                                                              .AsQueryable()
                                                                              .ToList());
            }
            catch (Exception ex)
            {
            }
            return localList;
        }

        public virtual async Task<T> Get(string id)
        {
            var item = await Task.Run(() => _dataLayer.Database.Connection.Table<T>()
                                                                          .AsQueryable()
                                                                          .FirstOrDefault(e => e.Id == id));
            return item;
        }

        public virtual async Task<T> Create(T entity)
        {
            _dataLayer.Database.Insert(entity);

            var item = _dataLayer.Database.Connection.Table<T>().AsQueryable()
                                                                   .FirstOrDefault(s => s.Id == entity.Id);
            return item as T;
        }

        public virtual async Task<bool> Update(T entity, string Id = "")
        {
            try
            {
                entity.Updated = DateTime.UtcNow;
                _dataLayer.Database.Update<T>(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual async Task<bool> Delete(object id)
        {
            try
            {
                _dataLayer.Database.DeleteObject<T>(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;   
            }
        }
    }
}
