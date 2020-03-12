using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Domain.Entity
{
    public class Sitipempresa
    {
        public int Tempcodi { get; set; }
        public string Tempdesc { get; set; }
        public string Tempabrev { get; set; }

        public ICollection<Sirelempresa> Sirelempresas { get; set; }
    }
}
