using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EasyDI.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace EasyDI.Unity.MVC
{
    public class UnityEasyDIEngineMVC : UnityDependencyInjectionEngine
    {
        public override void BuildDependencies()
        {
            base.BuildDependencies();
            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
        }
    }
}
