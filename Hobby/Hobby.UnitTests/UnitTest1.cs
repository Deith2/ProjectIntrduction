using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby.Data.Interface;
using Hobby.DTO;
using Hobby.DTO.Mappings;
using Hobby.UnitTests.TestingTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;

namespace Hobby.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserDTO user = new UserDTO
                {
                    Login = "test2"
                };

            //context.Users.Add(user);
            //context.SaveChanges();
        }

        [TestMethod]
        public void TestMethod2()
        {
            //var test = context.Users.FirstOrDefault(p => p.Login.Contains("test"));
            using (SimpleInjector.SimpleInjectorConsole.Instance.BeginLifetimeScope())
            {
                var uow = IoCCProvider.Container.GetInstance<IUnitOfWork>();

                var user = new UserDTO
                {
                    Login = "darek"
                };
               
                uow.Users.Add(user.Map());
                uow.Save();

                var test = uow.Users.Single(p => p.Id == 1);
                
                string test2 = string.Empty;
            }            
        }
    }
}
