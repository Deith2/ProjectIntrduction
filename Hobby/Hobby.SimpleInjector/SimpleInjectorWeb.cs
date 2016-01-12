using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Hobby.Data;
using Hobby.Data.Interface;
using SimpleInjector;
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

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            //#if DEBUG
            //            container.Verify();
            //#endif

            return container;
        }
    }
}
