using Hobby.Ninject.Commons;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.UnitTests.TestingTools
{
    public static class IoCNinjectProvider
    {
        public static IKernel Instance
        {
            get 
            {
                return NinjectConsoleCommon.Instance();
            }
        }
    }
}
