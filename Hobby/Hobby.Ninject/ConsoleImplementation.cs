using Hobby.Data;
using Hobby.Data.Interface;
using Hobby.Services;
using Hobby.Services.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Ninject
{
    public class ConsoleImplementation
    {
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel Instance()
        {
            var kernel = new StandardKernel();
            try
            {
                NinjectConsole.Container(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

    }
}
