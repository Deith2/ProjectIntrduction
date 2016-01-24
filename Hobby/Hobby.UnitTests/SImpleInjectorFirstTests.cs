using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby.Data.Interface;
using Hobby.DTO;
using Hobby.Ninject;
using Hobby.Services.Interfaces;
using Hobby.Services.Mappings;
using Hobby.UnitTests.TestingTools;
using Ninject;

namespace Hobby.UnitTests
{
    [TestsOwner("dlukasik")]
    [TestClass]
    public class SImpleInjectorFirstTests
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
                    Login = "darek3",
                    Password = "2"
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

        [TestMethod]
        public void TestUserPermissions()
        {
            using (SimpleInjector.SimpleInjectorConsole.Instance.BeginLifetimeScope())
            {
                var uow = IoCCProvider.Container.GetInstance<IUnitOfWork>();

                var categorie = new CategorieDTO
                {
                    Name = "testCategorie1"
                };

                var permissions = new PermissionDTO
                {
                    Name = "testPermission1",
                    Active = true,
                    Description = "TEST"
                };

                var user = new UserDTO
                {
                    Login = "testlogin1",
                    Password = "test"
                };
                //Trzeba przypsiac do obiektu
                var entityCat = categorie.Map();
                var entityPer = permissions.Map();
                var entityUse = user.Map();
                   
                uow.Categories.Add(entityCat);
                uow.Permissions.Add(entityPer);
                uow.Users.Add(entityUse);
                uow.Save();               

                var userPermission = new UserPermissionDTO()
                {
                    IdCategorie = entityCat.Id,
                    IdPermission = entityPer.Id,
                    IdUser = entityUse.Id
                };
                uow.UserPermissions.Add(userPermission.Map());
                uow.Save();
            }
        }
    }
}
