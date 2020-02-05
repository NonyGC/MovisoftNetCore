using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movisoft.Domain.Interfaces.Repository
{
    public interface IPersonaRepository : IDapperRepository<Persona>
    {
        List<Persona> ObtenerPorNombre(string nombre);
    }
}
