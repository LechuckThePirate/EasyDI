using System.Web.Mvc;
using Autofac.Integration.Mvc;

namespace EasyDI.Autofac.MVC
{
    public class AutofacEasyDIEngineMVC : AutofacEasyDIEngine
    {
        public override void BuildDependencies()
        {
            base.BuildDependencies();
            var resolver = new AutofacDependencyResolver(Container);
            DependencyResolver.SetResolver(resolver);
        }
    }
}
