using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpertGroup.CubeSummation.Domain.Entities;

namespace XpertGroup.CubeSummation.Application.Validator
{
    public class CubeValidator : AbstractValidator<Cube>
    {
        public CubeValidator(int testCases)
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleSet("CheckOrdersExecuted", () =>
            {
                this.RuleFor(cube => cube.ExecutedOrders).GreaterThanOrEqualTo(testCases).WithMessage("KO");
            });
        }
    }
}
