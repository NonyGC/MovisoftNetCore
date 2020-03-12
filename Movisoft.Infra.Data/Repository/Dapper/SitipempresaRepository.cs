using Dommel;
using Microsoft.Extensions.Configuration;
using Movisoft.Domain.Entity;
using Movisoft.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Movisoft.Infra.Data.Repository.Dapper
{
    public class SitipempresaRepository : DapperRepository<Sitipempresa>, ISitipempresaRepository
    {
        public SitipempresaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public int? Save(Sirelempresa sirelempresa, IDbConnection connection, IDbTransaction transaction)
        {
            return (int?)connection.Insert(sirelempresa, transaction);
        }
    }
}
