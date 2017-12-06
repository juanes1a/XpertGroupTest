using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpertGroup.Test.Domain.Interfaces;

namespace XpertGroup.Test.Services.DependencyResolution.Operator
{
    public class Installer : IWindsorInstaller
    {
        public Installer()
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
