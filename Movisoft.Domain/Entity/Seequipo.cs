using LinqToDB.Mapping;
using Movisoft.Domain.Common;
using System;
using System.Collections.Generic;
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
        public string Equiestado { get; set; }

        public void Inactivo()
        {
            this.Equiestado = ConstantesBase.Inactivo;
        }
        public void Activo()
        {
            this.Equiestado = ConstantesBase.Activo;
        }

        public void Actualizar(int topcodi, int tequicodi, int emprcodi, string equinombre, string equiabrev)
        {
            this.Topcodi = topcodi;
            this.Tequicodi = tequicodi;
            this.Emprcodi = emprcodi;
            this.Equinombre = equinombre;
            this.Equiabrev = equiabrev;
        }

    }
}
