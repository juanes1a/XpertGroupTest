using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpertGroup.CubeSummation.Domain.Interfaces;

namespace XpertGroup.CubeSummation.Services.DependencyResolution.Operator
{
    public class OperatorInstaller : IWindsorInstaller
    {
        public OperatorInstaller()
        {
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IOperator>().ImplementedBy<Application.Operator.Operator>().Named("Operator")
                    .LifestylePerWebRequest()
                );
        }
    }
}
