using Dapper;
using Microsoft.Extensions.Configuration;
using Movisoft.Domain.Entity;
using Movisoft.Domain.Interfaces.Repository;
using Movisoft.Infra.Data.Helper;
using System.Collections.Generic;

namespace Movisoft.Infra.Data.Repository.Dapper
{
    public class SiempresaRepository : DapperRepository<Siempresa>, ISiempresaRepository
    {
        private readonly SiempresaHelper _siempresaHelper;
        public SiempresaRepository(IConfiguration configuration, SiempresaHelper siempresaHelper) 
            : base(configuration)
        {
            _siempresaHelper = siempresaHelper;
        }

        public IEnumerable<Siempresa> ObtenerListSelectItem()
        {
            return dbConnection.Query<Siempresa>(_siempresaHelper.SqlObtenerListSelectItem);
        }
    }
}
