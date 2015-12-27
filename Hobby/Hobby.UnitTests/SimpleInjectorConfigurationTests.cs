using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.UnitTests
{
    [TestClass]

    public class SimpleInjectorConfigurationTests
    {
        [TestMethod]
        public void ecommerceConsoleConfigurationTest()
        {
            var instance = Hobby.SimpleInjector.SimpleInjectorConsole.Instance;
        }

        [TestMethod]
        public void ecommerceWebAdminConfigurationTest()
        {
            var container = Hobby.SimpleInjector.SimpleInjectorWeb.Instance;
            container.Verify();
        }
    }
}
