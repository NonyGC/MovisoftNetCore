﻿using FluentValidation;
using Movisoft.Aplication.DTO;

namespace Movisoft.Aplication.Validations
{
    public  class SeequipoValidador : AbstractValidator<SeequipoDTO>
    {
        protected void ValidarCodigo()
        {
            RuleFor(x => x.Equicodi)
                .NotEqual(default(int))
                .WithMessage("Código no es valido.");
        }

        protected void ValidarNombre()
        {
            RuleFor(x => x.Equinombre)
                .NotEmpty().WithMessage("Falta ingresar el nombre.")
                .Length(2, 150).WithMessage("El nombre debe tener entre 2 y 150 caracteres.");
        }
        protected void ValidarAbreatura()
        {
            RuleFor(x => x.Equiabrev)
                .NotEmpty().WithMessage("Falta ingresar la abreviatura.")
                .Length(2, 5).WithMessage("La abreviatura debe tener entre 2 y 5 caracteres.");
        }

        protected void ValidarDependencias()
        {
            RuleFor(x => x.Topcodi)
                .NotEqual(default(int))
                .WithMessage("Falta seleccionar la topologia.");  
            
            RuleFor(x => x.Emprcodi)
                .NotEqual(default(int))
                .WithMessage("Falta seleccionar la empresa.");  
            
            RuleFor(x => x.Tequicodi)
                .NotEqual(default(int))
                .WithMessage("Falta seleccionar el tipo de equipo.");
        }

    }

    public class SeequipoValidadorInsertar : SeequipoValidador
    {
        public SeequipoValidadorInsertar()
        {
            ValidarNombre();
            ValidarDependencias();
            ValidarAbreatura();
        }
    }

    public class SeequipoValidadorActualizar : SeequipoValidador
    {
        public SeequipoValidadorActualizar()
        {
            ValidarCodigo();
            ValidarNombre();
            ValidarDependencias();
            ValidarAbreatura();
        }
    }


}