using Movisoft.Aplication.DTO;
using Movisoft.MVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movisoft.MVC.Areas.Equipamiento.Models
{
    public class VMEquipamiento
    {
        public List<SeequipoDTO> ListaSeequipo { get; set; }
        public List<SetipequipoDTO> ListaSetipequipo { get; set; }
        public SeequipoDTO Seequipo { get; set; }
        public SetipequipoDTO Setipequipo { get; set; }
        public List<SelectListItemDTO> ListSelectItem { get; internal set; }
        public List<List<SelectListItemDTO>> ListSelectItems { get; set; }
        public SetopologiaDTO Setopologia { get; internal set; }
        public List<SetopologiaDTO> ListaSetopologia { get; internal set; }
    }
}
