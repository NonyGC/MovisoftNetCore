using Microsoft.Extensions.Configuration;
using Movisoft.Domain.Entity;
using Movisoft.Domain.Interfaces.Repository;

namespace Movisoft.Infra.Data.Repository.Dapper
{
    public class SiempresaRepository : DapperRepository<Siempresa>, ISiempresaRepository
    {
        public SiempresaRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
