using Hobby.Data;
using Hobby.Data.Interface;
using Hobby.Ninject.Containers;
using Hobby.Services;
using Hobby.Services.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Ninject.Commons
{
    public class NinjectConsoleCommon
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
                NinjectConsoleContainer.Container(kernel);

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
