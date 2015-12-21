using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.UnitTests.TestingTools
{
    public static class IoCCProvider
    {
        private static Container container = null;

        public static Container Container
        {
            get
            {
                if (container == null)
                {
                    container = Hobby.SimpleInjector.SimpleInjectorWeb.Instance;
                }

                return container;
            }
        }
    }
}
