using Movisoft.Aplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movisoft.MVC.Areas.Configuracion.Models
{
    public class VMConfiguracion
    {
        public IEnumerable<SitipempresaDTO> ListaSitipempresa { get; internal set; }
    }
}
