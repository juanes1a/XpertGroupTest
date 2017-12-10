using System;
using System.Web;
using Castle.Windsor;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;

namespace XpertGroupTest.App_Code
{
    public class Global : HttpApplication, IContainerAccessor
    {

        private static IWindsorContainer container;

        public Global()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        IWindsorContainer IContainerAccessor.Container
        {
            get { return Container; }
        }

        public static IWindsorContainer Container
        {
            get
            {
                return container;
            }
            private set
            {
                container = value;
            }
        }

        private void InitializeIoC()
        {

            var ioc = Ragolo.Core.IoC.IocHelper.Instance;
            var container = ioc.GetContainer();

            ioc.Install(new XpertGroup.Test.Services.DependencyResolution.Operator.OperatorInstaller());
            ioc.Install(new XpertGroup.Test.Services.DependencyResolution.Orchestrator.OrchestratorInstaller());
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            Container = container;

        }

        void Application_Start(object sender, EventArgs e)
        {
            InitializeIoC();
            // Code that runs on application startup
        }

    }
}