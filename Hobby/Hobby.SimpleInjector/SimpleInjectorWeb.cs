using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hobby.SimpleInjector
{
    public class SimpleInjectorWeb
    {
        private static Container _instance;

        public static Container Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = CreateContainer();
                }

                return _instance;
            }
        }

        internal static Container CreateContainer()
        {
            Container container = new Container();

#if DEBUG
            container.Verify();
#endif
            return container;
        }

    }
}
