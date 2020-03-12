using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Movisoft.Domain.Interfaces.Repository
{
    public interface ISitipempresaRepository : IDapperRepository<Sitipempresa>
    {
        int? Save(Sirelempresa sirelempresa, IDbConnection connection, IDbTransaction transaction);
    }
}
