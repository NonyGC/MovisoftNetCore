using Microsoft.Extensions.Configuration;
using Movisoft.Domain.Interfaces.UoW;
using Npgsql;
using System;
using System.Data;

namespace Movisoft.Infra.Data.UoW
{
    public class UnitOfWorkDapper : IUnitOfWorkDapper
    {
        private readonly IConfiguration _configuration;
        protected readonly IDbConnection _connection;

        public UnitOfWorkDapper(IConfiguration configuration)
        {
            _configuration = configuration;
            Id = Guid.NewGuid();
            _connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            if (_connection.State== ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public IDbTransaction Transaction { get; private set; }
        public IDbConnection Connection => _connection;
        public Guid Id { get; }

        public void Begin()
        {
            Transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction.Commit();
            Dispose();
        }

        public void Dispose()
        {
            if (Transaction != null)
                Transaction.Dispose();
            Transaction = null;
            _connection.Dispose();
        }

        public void Rollback()
        {
            Transaction.Rollback();
            Dispose();
        }
    }
}
