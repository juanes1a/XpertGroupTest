using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XpertGroup.CubeSummation.WebSite.App_Code.Windsor
{
    public interface IContainerAccessor
    {
        Unity.IUnityContainer Container { get; }
    }
}