using FluentValidation;
using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Validations
{
    public class SetopologiaValidator : AbstractValidator<Setopologia>
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

    public class SetopologiaInsertValidator : SetopologiaValidator
    {
        public SetopologiaInsertValidator()
        {
            ValidarNombre();
        }
    }

    public class SetopologiaUpdateValidator : SetopologiaValidator
    {
        public SetopologiaUpdateValidator()
        {
            ValidarCodigo();
            ValidarNombre();
        }
    }
}
