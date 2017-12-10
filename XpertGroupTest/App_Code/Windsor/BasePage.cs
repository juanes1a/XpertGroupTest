using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Unity;

namespace XpertGroupTest.App_Code.Windsor
{
    /// <summary>
    /// Summary description for BasePage
    /// </summary>
    public abstract class BasePage<T> : Page where T : class
    {

        protected override void OnPreInit(EventArgs e)

        {

            InjectDependencies();

            base.OnPreInit(e);

        }

        protected virtual void InjectDependencies()
        {

            var context = HttpContext.Current;

            if (context == null)
            {
                return;
            }

            IContainerAccessor accessor = context.ApplicationInstance as IContainerAccessor;

            if (accessor == null)
            {
                return;
            }

            IUnityContainer container = accessor.Container;

            if (container == null)
            {
                throw new InvalidOperationException("No Unity container found");
            }

            container.BuildUp(this as T);

        }
    }
}