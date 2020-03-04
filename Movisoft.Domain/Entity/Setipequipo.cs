using Movisoft.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Domain.Entity
{
    public class Setipequipo
    {
        public int Tequicodi { get; set; }
        public string Tequinomb { get; set; }
        public string Tequiestado { get; set; }

        public void Inactivo()
        {
            this.Tequiestado = ConstantesBase.Inactivo;
        } 
        public void Activo()
        {
            this.Tequiestado = ConstantesBase.Activo;
        }

        public void CompletarEstado()
        {
            switch (this.Tequiestado)
            {
                case ConstantesBase.Inactivo:
                    this.Tequiestado= "Inactivo";
                    break;
                case ConstantesBase.Activo:
                    this.Tequiestado = "Activo";
                    break;
            }
        }

        public void Actualizar(string tequinomb)
        {
            this.Tequinomb = tequinomb;
        }
    }

}
