using Hobby.Common.Authentication;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hobby.UnitTests.Utilities.UserUtilities
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void UserUtilities_HashPasswordTest()
        {
            //Arrange

            string expectedValue2 = "da4b9237bacccdf19c0760cab7aec4a8359010b0".ToUpper();
            //Act
            var result = HashPassowrd.getSHA1("2");
            //Assert
            Assert.AreEqual(result, expectedValue2);
        }
    }
}
