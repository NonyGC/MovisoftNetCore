using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.CrossCutting.Identity.DTO
{
    public class DatatablesDTO
    {
        public int draw { get; set; }
        public int recordsTotal { get; internal set; }
        public int recordsFiltered { get; internal set; }
        public dynamic data { get; set; }
    }
}
