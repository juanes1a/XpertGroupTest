using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace XpertGroup.CubeSummation.WebSite
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            InitializeIoC();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static IWindsorContainer container;

        public Global()
        {
            //
            // TODO: Add constructor logic here
            //
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

            ioc.Install(new XpertGroup.CubeSummation.Services.DependencyResolution.Operator.OperatorInstaller());
            ioc.Install(new XpertGroup.CubeSummation.Services.DependencyResolution.Orchestrator.OrchestratorInstaller());
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            Container = container;

        }
    }
}