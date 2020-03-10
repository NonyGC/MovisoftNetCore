using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.DTO
{
    public class AppResult
    {
        public AppResult(ValidationResult validador)
        {
            this.ValidationResult = validador;
        }

        public ValidationResult ValidationResult { get; set; }
    }
}
