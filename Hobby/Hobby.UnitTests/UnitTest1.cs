using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby.Data;
using Hobby.Data.Interface;
using Hobby.Entities;
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
            User user = new User
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
                var user = new User
                {
                    Login = "darek"
                };
                uow.Users.Add(user);
                uow.Save();
                string test2 = string.Empty;
            }            
        }
    }
}
