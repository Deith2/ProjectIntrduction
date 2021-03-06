﻿using Hobby.Common.Authentication;
using Hobby.DTO;
using Hobby.Services.Interfaces;
using Hobby.UnitTests.TestingTools;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;
using System.Collections.Generic;
using Hobby.Data.Interface;

namespace Hobby.UnitTests.Services
{
    [TestClass]
    [TestsOwner("dlukasik")]
    public class UserServiceTests
    {
        [TestMethod]
        public void UserService_CheckUser()
        {
            //Arrange         
            var userDTO = new UserDTO
            {
                CreateDate = DateTime.Now,
                Email = "test@test.pl",
                Id = 1,
                FirstName = "test",
                LastName = "test",
                Password = "2".getSHA1()
            };

            Mock<IAuthenticateService> mockService = new Mock<IAuthenticateService>();
            mockService.Setup(_test => _test.CheckUser("test", "2")).Returns(userDTO);

            //Act           
            var result = mockService.Object.CheckUser("test", "2").Id;

            //Arrange
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UserService_PermissionActiveNameList()
        {
            //Arrange
            Mock<IAuthenticateService> mockService = new Mock<IAuthenticateService>();
            mockService.Setup(_test => _test.PermissionActiveNameList(1)).Returns(new List<string> 
            {
                "Admin",
                "View"
            });

            //Act
            var result = mockService.Object.PermissionActiveNameList(1);
            var resultFail = mockService.Object.PermissionActiveNameList(2);

            //Assert
            Assert.AreEqual("Admin", result[0]);
            Assert.IsNull(resultFail);
        }

        [TestMethod]
        public void editMethodTest()
        {
            var uow = IoCNinjectProvider.Instance.Get<IUnitOfWork>();

            var user = uow.Users.GetById(1);

            user.LastName = "test2";
            user.FirstName = "test2";

            uow.Save();
        }
    }
}
