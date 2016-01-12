using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hobby.UnitTests
{
    [TestClass]

    public class SimpleInjectorConfigurationTests
    {
        [TestMethod]
        public void HobbyConsoleConfigurationTest()
        {
            var instance = Hobby.SimpleInjector.SimpleInjectorConsole.Instance;
        }

        [TestMethod]
        public void HobbyWebAdminConfigurationTest()
        {
            var container = Hobby.SimpleInjector.SimpleInjectorWeb.Instance;
            container.Verify();
        }
    }
}
