using FluentValidation;
using Movisoft.Aplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Validations
{
    public class SetopologiaValidador: AbstractValidator<SetopologiaDTO>
    {
        protected void ValidarCodigo()
        {
            RuleFor(x => x.Topcodi)
                .NotEqual(default(int))
                .WithMessage("Código no es valido."); ;
        }

        protected void ValidarNombre()
        {
            RuleFor(x => x.Topnombre)
                .NotEmpty().WithMessage("Falta ingresar el nombre.")
                .Length(2, 50).WithMessage("El nombre debe tener entre 2 y 50 caracteres.");
        }
    }

    public class SetopologiaValidadorInsertar : SetopologiaValidador
    {
        public SetopologiaValidadorInsertar()
        {
            ValidarNombre();
        }
    }

    public class SetopologiaValidadorActualizar: SetopologiaValidador
    {
        public SetopologiaValidadorActualizar()
        {
            ValidarCodigo();
            ValidarNombre();
        }
    }

}
