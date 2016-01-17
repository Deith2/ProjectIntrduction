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
            var container = Hobby.SimpleInjector.SimpleInjectorConsole.Instance;
            container.Verify();
        }

        [TestMethod]
        public void HobbyWebConfigurationTest()
        {
            var container = Hobby.SimpleInjector.SimpleInjectorWeb.Instance;
            container.Verify();
        }
    }
}
