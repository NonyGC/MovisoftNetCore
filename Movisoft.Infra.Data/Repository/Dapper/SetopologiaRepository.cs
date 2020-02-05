using Microsoft.Extensions.Configuration;
using Movisoft.Domain.Entity;
using Movisoft.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Infra.Data.Repository.Dapper
{
    public class SetopologiaRepository : DapperRepository<Setopologia>, ISetopologiaRepository
    {
        public SetopologiaRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
