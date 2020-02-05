using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Movisoft.Domain.Entity
{
    public class Seequipo
    {
        public int Equicodi { get; set; }
        public int Topcodi { get; set; }
        public string Equinombre { get; set; }
        public string Equiabrev { get; set; }
        public int Tequicodi { get; set; }
        public int Emprcodi { get; set; }
        public Setipequipo Setipequipo { get; set; }
        public Setopologia Setopologia { get; set; }
        public Siempresa Siempresa { get; set; }
    }
}
