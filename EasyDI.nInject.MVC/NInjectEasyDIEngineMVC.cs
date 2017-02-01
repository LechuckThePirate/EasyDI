using System.Web.Mvc;
using Ninject.Web.Mvc;

namespace EasyDI.nInject.MVC
{
    public class NInjectEasyDIEngineMVC : NInjectEasyDIEngine
    {
        public override void BuildDependencies()
        {
            base.BuildDependencies();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(Kernel));
        }
    }
}
