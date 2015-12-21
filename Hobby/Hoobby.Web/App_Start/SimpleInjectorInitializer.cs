using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using SimpleInjector.Integration.Web.Mvc;

namespace Hobby.Web.App_Start
{
    public class SimpleInjectorInitializer
    {
        public static Container Initialize()
        {
            var container = SimpleInjector.SimpleInjectorWeb.Instance;
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();

#if DEBUG
            container.Verify();
#endif

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            return container;
        }
    }
}