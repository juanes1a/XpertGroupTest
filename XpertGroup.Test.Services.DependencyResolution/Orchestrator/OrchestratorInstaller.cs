using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using XpertGroup.Test.Domain.Interfaces.Orchestrator;

namespace XpertGroup.Test.Services.DependencyResolution.Orchestrator
{
    public class OrchestratorInstaller : IWindsorInstaller
    {
        public OrchestratorInstaller()
        {
        }


        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IOrchestrator>().ImplementedBy<Services.Orchestrator.Orchestrator>().Named("Orchestrator")
                    .LifestylePerWebRequest()
                );
        }
    }
}
