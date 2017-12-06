using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpertGroup.Test.Domain.Entities;

namespace XpertGroup.Test.Application.Validator
{
    public class UpdateValidator : AbstractValidator<Update>
    {
        public UpdateValidator(int matrixDimension)
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleSet("General", () =>
            {
                this.RuleFor(update => update.CoordinateX).GreaterThanOrEqualTo(1).LessThanOrEqualTo(matrixDimension).NotEmpty().WithMessage($"La coordenada X debe ser mayor o igual a 1 y menor o igual a {matrixDimension}");
                this.RuleFor(update => update.CoordinateY).GreaterThanOrEqualTo(1).LessThanOrEqualTo(matrixDimension).NotEmpty().WithMessage($"La coordenada Y debe ser mayor o igual a 1 y menor o igual a {matrixDimension}");
                this.RuleFor(update => update.CoordinateZ).GreaterThanOrEqualTo(1).LessThanOrEqualTo(matrixDimension).NotEmpty().WithMessage($"La coordenada Z debe ser mayor o igual a 1 y menor o igual a {matrixDimension}");

                this.RuleFor(update => update.Value).GreaterThanOrEqualTo(long.MaxValue).LessThanOrEqualTo(long.MinValue).NotEmpty().WithMessage($"El valor a actualizar debe ser mayor a {long.MinValue} y menor a {long.MaxValue}");
            });
        }
    }
}
