using FluentValidation;
using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Validations
{
    public class SitipempresaValidator: AbstractValidator<Sitipempresa>
    {
        protected void ValidarCodigo()
        {
            RuleFor(x => x.Tempcodi)
                .NotEqual(default(int))
                .WithMessage("Código no es valido."); ;
        }

        protected void ValidarDescripcion()
        {
            RuleFor(x => x.Tempdesc)
                .NotEmpty().WithMessage("Falta ingresar la descripción.");
        }    
        
        protected void ValidarAbreviatura()
        {
            RuleFor(x => x.Tempabrev)
                .NotEmpty().WithMessage("Falta ingresar la abreviatura.");
        }
    }

    public class SitipempresaInsertValidator: SitipempresaValidator
    {
        public SitipempresaInsertValidator()
        {
            ValidarDescripcion();
            ValidarAbreviatura();
        }
    }

    public class SitipempresaUpdateValidator: SitipempresaValidator
    {
        public SitipempresaUpdateValidator()
        {
            ValidarCodigo();
            ValidarDescripcion();
            ValidarAbreviatura();
        }
    }

}
