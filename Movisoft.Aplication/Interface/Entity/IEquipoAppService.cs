

using Movisoft.Aplication.DTO;
using Movisoft.Domain.Entity;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Interface.Entity
{
    public interface ISeequipoAppService : IBaseAppService<SeequipoDTO, Seequipo>
    {
        List<SeequipoDTO> ObtenerListaPorEstado(string estado);
        int? Save(SeequipoDTO seequipoDTO);
        bool ActualizarAEstadoInactivo(int id);
        bool Actualizar(SeequipoDTO seequipoDTO);
        int? Insertar(SeequipoDTO seequipoDTO);
    }

}
