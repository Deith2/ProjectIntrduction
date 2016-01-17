using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby.Data.Interface;
using Hobby.DTO;
using Hobby.Services.Mappings;
using Hobby.UnitTests.TestingTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;

namespace Hobby.UnitTests
{
    [TestsOwner("dlukasik")]
    [TestClass]
    public class FirstTests
    {
        [TestMethod]
        public void TestMapping()
        {
            //var test = context.Users.FirstOrDefault(p => p.Login.Contains("test"));
            using (SimpleInjector.SimpleInjectorConsole.Instance.BeginLifetimeScope())
            {
                var uow = IoCCProvider.Container.GetInstance<IUnitOfWork>();

                var user = new UserDTO
                {
                    Login = "darek3"
                };

                uow.Users.Add(user.Map());
                uow.Save();

                var test = uow.Users.Single(p => p.Id == 1);

                string test2 = string.Empty;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]   
        public void TestRelations()
        {
            using (SimpleInjector.SimpleInjectorConsole.Instance.BeginLifetimeScope())
            {
                var uow = IoCCProvider.Container.GetInstance<IUnitOfWork>();

                var setting = new SettingDTO
                {
                    IdUser = 10000000,
                    Name = "test",
                    Value = true
                };

                uow.Settings.Add(setting.Map());
                uow.Save();                
            }
        }
    }
}
