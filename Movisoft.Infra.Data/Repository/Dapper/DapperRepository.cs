using Dapper.FluentMap;
using Dommel;
using Microsoft.Extensions.Configuration;
using Movisoft.Domain.Interfaces.Repository;
using Movisoft.Infra.Data.DapperConfig;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;

namespace Movisoft.Infra.Data.Repository.Dapper
{
    public class DapperRepository<TEntity> : IDapperRepository<TEntity> where TEntity : class
    {
        private readonly IConfiguration _configuration;
        protected readonly IDbConnection dbConnection;

        public DapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            if (FluentMapper.EntityMaps.IsEmpty)
            {
                FluentMapperConfig.RegisterMappings();
            }
            dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public virtual object Add(TEntity obj) => dbConnection.Insert(obj);

        public virtual IEnumerable<TEntity> GetAll() =>dbConnection.GetAll<TEntity>();

        public virtual TEntity GetById(int? id) => dbConnection.Get<TEntity>(id);

        public virtual bool Remove(TEntity obj) => dbConnection.Delete(obj);

        public virtual bool RemoveById(int? id) => Remove(GetById(id));

        public virtual bool Update(TEntity obj) => dbConnection.Update(obj);

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate) => dbConnection.Select(predicate);


        private bool _disposed = false;

        ~DapperRepository() => Dispose();

        public void Dispose()
        {
            if (!_disposed)
            {
                dbConnection.Close();
                dbConnection.Dispose();
                
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }


    }
}
