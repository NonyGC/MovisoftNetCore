using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Domain.Entity
{
    public class Siempresa
    {
		public int Emprcodi { get; set; }
		public string Emprnomb { get; set; }
		public string Emprdire { get; set; }
		public string Emprtele { get; set; }
		public string Emprruc { get; set; }
		public string Emprabrev { get; set; }
		public string Emprdom { get; set; }
		public string Emprsein { get; set; }
		public string Emprrazsocial { get; set; }
		public string Emprcoes { get; set; }
		public string Lastuser { get; set; }
		public TimeSpan Lastdate { get; set; }
		public string Emprestado { get; set; }
		public string Emprcodosinergmin { get; set; }
		public string Emprdomiciliada { get; set; }
		public string Emprambito { get; set; }
		public int Emprrubro { get; set; }

		public ICollection<Sirelempresa> Sirelempresas { get; set; }
	}
}
