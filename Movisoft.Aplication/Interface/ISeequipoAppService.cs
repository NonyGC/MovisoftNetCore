
using Movisoft.Aplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Interface
{
    public interface ISeequipoAppService : IBaseAppService<SeequipoDTO>
    {
        List<SeequipoDTO> ObtenerListaEquipos();
    }
}
