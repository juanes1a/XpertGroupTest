using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpertGroup.CubeSummation.Domain.Entities;

namespace XpertGroup.CubeSummation.Application.Validator
{
    public class QueryValidator : AbstractValidator<Query>
    {
        public QueryValidator(int matrixDimension)
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleSet("General", () =>
            {
                this.RuleForEach(query => query.CoordinatesX).GreaterThanOrEqualTo(1).LessThanOrEqualTo(matrixDimension).NotEmpty().WithMessage("Las coordenadas X deben ser mayores o iguales a 1 y menores o iguales a " + matrixDimension);
                this.RuleForEach(query => query.CoordinatesY).GreaterThanOrEqualTo(1).LessThanOrEqualTo(matrixDimension).NotEmpty().WithMessage("Las coordenadas Y deben ser mayores o iguales a 1 y menores o iguales a " + matrixDimension);
                this.RuleForEach(query => query.CoordinatesZ).GreaterThanOrEqualTo(1).LessThanOrEqualTo(matrixDimension).NotEmpty().WithMessage("Las coordenadas Z deben ser mayores o iguales a 1 y menores o iguales a " + matrixDimension);
            });
        }
    }
}
