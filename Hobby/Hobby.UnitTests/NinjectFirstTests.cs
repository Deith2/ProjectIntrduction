using Hobby.Data.Interface;
using Hobby.DTO;
using Hobby.Services.Interfaces;
using Hobby.Services.Mappings;
using Hobby.UnitTests.TestingTools;
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
                Login = "darek4",
                Password = "2"
            };

            uow.Users.Add(user.Map());
            uow.Save();
        }

        [TestMethod]
        public void NinjectUserService()
        {
            var _userService = IoCNinjectProvider.Instance.Get<IUserService>();

            var dto = _userService.test();
        }
    }
}
