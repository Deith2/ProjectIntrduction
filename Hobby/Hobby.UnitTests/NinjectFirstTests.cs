using Hobby.Data.Interface;
using Hobby.DTO;
using Hobby.Services.Interfaces;
using Hobby.Services.Mappings;
using Hobby.UnitTests.TestingTools;
using Hobby.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Hobby.UnitTests
{
    [TestsOwner("dlukasik")]
    [TestClass]
    public class NinjectFirstTests
    {
        [TestMethod]
        public void NinjectFirstMethod()
        {
            var uow = IoCNinjectProvider.Instance.Get<IUnitOfWork>();

            var user = new UserDTO
            {
                Email = "czarnuch1001@gmail.com",
                Login = "darek4",
                Password = "2"
            };

            user.Password = user.Password.getSHA1();
            var entity = user.Map();
            uow.Users.Add(entity);
            uow.Save();

            Assert.IsNotNull(entity.Id);
        }

        [TestMethod]
        public void NinjectUserService()
        {
            var _userService = IoCNinjectProvider.Instance.Get<IUserService>();

            //var dto = _userService.test();

            //Assert.IsNotNull(dto);
        }
    }
}
