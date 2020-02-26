using Movisoft.Aplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Interface
{
    public interface ISharedAppService
    {
        List<SelectListItemDTO> ObtenerSelectItemTipoEquipo();
        List<SelectListItemDTO> ObtenerSelectItemEmpresa();
        List<SelectListItemDTO> ObtenerSelectItemTopologia();
    }
}
