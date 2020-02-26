
using Movisoft.Aplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Interface
{
    public interface IEquipoAppService : IBaseAppService<SeequipoDTO>
    {
        List<SeequipoDTO> ObtenerListaEquipos();
        int? Save(SeequipoDTO seequipoDTO);
    }
}
