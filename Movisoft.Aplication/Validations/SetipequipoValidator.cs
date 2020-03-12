using FluentValidation;
using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Validations
{
    public class SetipequipoValidator : AbstractValidator<Setipequipo>
    {
        protected void ValidarCodigo()
        {
            RuleFor(x => x.Tequicodi)
                .NotEqual(default(int))
                .WithMessage("Código no es valido."); ;
        }

        protected void ValidarNombre()
        {
            RuleFor(x => x.Tequinomb)
                .NotEmpty().WithMessage("Falta ingresar el nombre.")
                .Length(2, 50).WithMessage("El nombre debe tener entre 2 y 50 caracteres.");
        }
    }


    public class SetipequipoInsertValidator : SetipequipoValidator
    {
        public SetipequipoInsertValidator()
        {
            ValidarNombre();
        }
    }

    public class SetipequipoUpdateValidator: SetipequipoValidator
    {
        public SetipequipoUpdateValidator()
        {
            ValidarCodigo();
            ValidarNombre();
        }
    }
}
