using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;

namespace XpertGroup.CubeSummation.WebSite.App_Code.Windsor
{
    public class WindsorHttpModule : IHttpModule
    {
        private HttpApplication application;
        private IWindsorContainer iocProvider;

        public void Init(HttpApplication context)
        {
            application = context;
            iocProvider = context as IWindsorContainer;

            if (iocProvider == null)
            {
                throw new InvalidOperationException("Application must implement IoCProvider");
            }

            application.PreRequestHandlerExecute += InitiateWindsor;
        }

        private void InitiateWindsor(object sender, System.EventArgs e)
        {
            Page currentPage = application.Context.CurrentHandler as Page;
            if (currentPage != null)
            {
                InjectPropertiesOn(currentPage);
                currentPage.InitComplete += delegate { InjectUserControls(currentPage); };
            }
        }

        private void InjectUserControls(Control parent)
        {
            if (parent.Controls != null)
            {
                foreach (Control control in parent.Controls)
                {
                    if (control is UserControl)
                    {
                        InjectPropertiesOn(control);
                    }
                    InjectUserControls(control);
                }
            }
        }

        private void InjectPropertiesOn(object currentPage)
        {
            var ctor = GetInjectableConstructor(currentPage.GetType().BaseType);

            if (ctor != null)
            {

                var args = (from parm in ctor.GetParameters()
                            select iocProvider.Resolve(parm.ParameterType))
                           .ToArray();

                ctor.Invoke(currentPage, args);

            }
        }

        private static ConstructorInfo GetInjectableConstructor(Type type)
        {

            var possibleConstructors = (
              from ctor in type.GetConstructors()
              where ctor.GetParameters().Length > 0
              select ctor).ToArray();

            if (possibleConstructors.Length == 0) return null;

            if (possibleConstructors.Length == 1) return possibleConstructors[0];

            throw new Exception("Unable to determine which constructor to inject");

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}