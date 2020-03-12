using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Movisoft.Domain.Interfaces.Repository
{
    public interface ISiempresaRepository : IDapperRepository<Siempresa>
    {
        IEnumerable<Siempresa> ObtenerListSelectItem();
        int? Save(Siempresa siempresa, IDbConnection connection, IDbTransaction transaction);
    }
}
