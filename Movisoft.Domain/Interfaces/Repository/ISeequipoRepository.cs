using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Movisoft.Domain.Interfaces.Repository
{
    public interface ISeequipoRepository : IDapperRepository<Seequipo>
    {
        List<Seequipo> ObtenerListaPorEstado(string estado);
        int Save(Seequipo seequipo, IDbConnection connection, IDbTransaction transaction);
    }
}
