using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Hobby.Data;
using Hobby.Data.Interface;
using Hobby.Services;
using Hobby.Services.Interfaces;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using SimpleInjector.Extensions.LifetimeScoping;

namespace Hobby.SimpleInjector
{
    public class SimpleInjectorWeb
    {
        private static Container _instance;

        public static Container Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Initialize();
                }

                return _instance;
            }
        }

        internal static Container Initialize()
        {
            Container container = new Container();

            //container.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();
            //container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            container.RegisterPerWebRequest<IUnitOfWork>(() => new UnitOfWork());

            container.RegisterPerWebRequest<IUserService, UserService>();

            //Registration registration = container.GetRegistration(typeof(IUnitOfWork)).Registration;

            //registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "OK");
            //#if DEBUG
            //            container.Verify();
            //#endif

            return container;
        }
    }
}
