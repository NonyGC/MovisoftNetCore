using Movisoft.Aplication.DTO;
using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Interface.Entity
{
    public interface ISetopologiaAppService : IBaseAppService<SetopologiaDTO, Setopologia>
    {
        int? Insertar(SetopologiaDTO setopologiaDTO);
        bool Actualizar(SetopologiaDTO setopologiaDTO);
        bool ActualizarAEstadoInactivo(int id);
        List<SetopologiaDTO> ObtenerListaPorEstado(string estado);
    }
}
