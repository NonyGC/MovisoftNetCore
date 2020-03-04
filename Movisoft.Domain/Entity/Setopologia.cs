using Movisoft.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Domain.Entity
{
    public class Setopologia
    {
        public int Topcodi { get; set; }
        public string Topnombre { get; set; }
        public string Topestado { get; set; }

        public void Actualizar(string topnombre)
        {
            this.Topnombre = topnombre;
        }

        public void Inactivo()
        {
            this.Topestado = ConstantesBase.Inactivo;
        }   
        
        public void Activo()
        {
            this.Topestado = ConstantesBase.Activo;
        }

        public void CompletarEstado()
        {
            switch (this.Topestado)
            {
                case ConstantesBase.Inactivo:
                    this.Topestado = "Inactivo";
                    break;
                case ConstantesBase.Activo:
                    this.Topestado = "Activo";
                    break;
            }
        }
    }
}
