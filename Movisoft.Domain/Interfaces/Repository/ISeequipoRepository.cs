using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Domain.Interfaces.Repository
{
    public interface ISeequipoRepository : IDapperRepository<Seequipo>
    {
        List<Seequipo> ObtenerListaEquipos();
    }
}
