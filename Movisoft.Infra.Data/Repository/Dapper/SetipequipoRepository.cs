using Microsoft.Extensions.Configuration;
using Movisoft.Domain.Entity;
using Movisoft.Domain.Interfaces.Repository;
using Movisoft.Infra.Data.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Infra.Data.Repository.Dapper
{
    public class SetipequipoRepository : DapperRepository<Setipequipo>, ISetipequipoRepository
    {
        private readonly SeequipoHelper _seequipoHelper;
        public SetipequipoRepository(IConfiguration configuration, SeequipoHelper seequipoHelper) : base(configuration)
        {
            _seequipoHelper = seequipoHelper;
        }

    }
}
