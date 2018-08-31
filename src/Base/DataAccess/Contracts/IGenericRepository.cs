using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperPowerEditor.Base.DataAccess.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> All();
        Task<IEnumerable<TEntity>> AllAsync();
        IEnumerable<TEntity> GetData(string qry, object parameters);
        Task<IEnumerable<TEntity>> GetDataAsync(string qry, object parameters);
        IEnumerable<TEntity> GetData(object filter);
        Task<IEnumerable<TEntity>> GetDataAsync(object filter);
        TEntity Find(object pksFields);
        Task<TEntity> FindAsync(object pksFields);
        int Add(TEntity entity);
        Task<int> AddAsync(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        Task AddAsync(IEnumerable<TEntity> entities);
        void Remove(object key);
        Task RemoveAsync(object key);
        bool Update(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
    }
}
