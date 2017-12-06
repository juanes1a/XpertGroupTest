using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpertGroup.Test.Domain.Entities;

namespace XpertGroup.Test.Application.Validator
{
    public class ConfigurationValidator : AbstractValidator<Configuration>
    {
        public ConfigurationValidator()
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleSet("General", () =>
            {
                this.RuleFor(configuration => configuration.MatrixDimension).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100).NotEmpty().WithMessage("La dimensión de la matriz debe ser mayor o igual a 1 y menor o igual a 100");
                this.RuleFor(configuration => configuration.TestCases).GreaterThanOrEqualTo(1).LessThanOrEqualTo(50).NotEmpty().WithMessage("Los números de casos deben ser entre 1 y 50");
                this.RuleFor(configuration => configuration.NumberOperations).GreaterThanOrEqualTo(1).LessThanOrEqualTo(1000).NotEmpty().WithMessage("Los números de operaciones deben ser entre 1 y 1000");
            });
        }

    }
}
