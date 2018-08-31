using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using SuperPowerEditor.Base.DataAccess.Contracts;

namespace SuperPowerEditor.Base.DataAccess.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly IConnectionFactory _connectionFactory;

        protected BaseRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<TEntity> All()
        {
            using (IDbConnection cn = _connectionFactory.GetConnection)
            {
                cn.Open();
                return cn.GetList<TEntity>();
            }
        }

        public async Task<IEnumerable<TEntity>> AllAsync()
        {
            using (IDbConnection cn = _connectionFactory.GetConnection)
            {
                cn.Open();
                return await cn.GetListAsync<TEntity>();
            }
        }

        public IEnumerable<TEntity> GetData(string qry, object parameters)
        {
            using (IDbConnection cn = _connectionFactory.GetConnection)
            {
                cn.Open();
                return cn.Query<TEntity>(qry, parameters);
            }
        }

        public async Task<IEnumerable<TEntity>> GetDataAsync(string qry, object parameters)
        {
            using (IDbConnection cn = _connectionFactory.GetConnection)
            {
                cn.Open();
                return await cn.QueryAsync<TEntity>(qry, parameters);
            }
        }

        public IEnumerable<TEntity> GetData(object filter)
        {
            using (IDbConnection cn = _connectionFactory.GetConnection)
            {
                cn.Open();
                return cn.GetList<TEntity>(filter);
            }
        }

        public async Task<IEnumerable<TEntity>> GetDataAsync(object filter)
        {
            using (IDbConnection cn = _connectionFactory.GetConnection)
            {
                cn.Open();
                return await cn.GetListAsync<TEntity>(filter);
            }
        }

        public TEntity Find(object filter)
        {
            using (IDbConnection cn = _connectionFactory.GetConnection)
            {
                cn.Open();
                return cn.Get<TEntity>(filter);
            }
        }

        public async Task<TEntity> FindAsync(object filter)
        {
            using (IDbConnection cn = _connectionFactory.GetConnection)
            {
                cn.Open();
                return await cn.GetAsync<TEntity>(filter);
            }
        }

        public int Add(TEntity entity)
        {
            using (IDbConnection cn = _connectionFactory.GetConnection)
            {
                cn.Open();
                return cn.Insert<TEntity>(entity);
            }
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            using (IDbConnection cn = _connectionFactory.GetConnection)
            {
                cn.Open();
                return await cn.InsertAsync<TEntity>(entity);
            }
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            using (IDbConnection cn = _connectionFactory.GetConnection)
            {
                cn.Open();
                cn.Insert<TEntity>(entities);
            }
        }

        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            using (IDbConnection cn = _connectionFactory.GetConnection)
            {
                cn.Open();
                await cn.InsertAsync<TEntity>(entities);
            }
        }

        public void Remove(object filter)
        {
            using (IDbConnection cn = _connectionFactory.GetConnection)
            {
                cn.Open();
                cn.Delete(filter);
            }
        }

        public async Task RemoveAsync(object filter)
        {
            using (IDbConnection cn = _connectionFactory.GetConnection)
            {
                cn.Open();
                await cn.DeleteAsync(filter);
            }
        }

        public bool Update(TEntity entity)
        {
            using (IDbConnection cn = _connectionFactory.GetConnection)
            {
                cn.Open();
                return cn.Update<TEntity>(entity);
            }
        }

        public Task<bool> UpdateAsync(TEntity entity)
        {
            using (IDbConnection cn = _connectionFactory.GetConnection)
            {
                cn.Open();
                return cn.UpdateAsync<TEntity>(entity);
            }
        }
    }
}
