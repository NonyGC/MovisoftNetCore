using FluentValidation;
using Movisoft.Aplication.DTO;

namespace Movisoft.Aplication.Validations
{
    public class SetipequipoValidador : AbstractValidator<SetipequipoDTO>
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


    public class SetipequipoValidadorInsertar : SetipequipoValidador
    {
        public SetipequipoValidadorInsertar()
        {
            ValidarNombre();
        }
    }

    public class SetipequipoValidadorActualizar : SetipequipoValidador
    {
        public SetipequipoValidadorActualizar()
        {
            ValidarCodigo();
            ValidarNombre();
        }
    }
}
