using Movisoft.Aplication.DTO;
using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Interface.Entity
{
    public interface ISetipequipoAppService : IBaseAppService<SetipequipoDTO, Setipequipo>
    {
        List<SetipequipoDTO> ObtenerListaPorEstado(string estado);
        bool ActualizarAEstadoInactivo(int id);
        bool Actualizar(SetipequipoDTO setipequipoDTO);
        int? Insertar(SetipequipoDTO setipequipoDTO);
    }
}
