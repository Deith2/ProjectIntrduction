using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hobby.Data;
using Hobby.Entities;

namespace Hobby.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private ModelEntities context;
        public UnitTest1()
        {
            this.context = new ModelEntities();
        }
        [TestMethod]
        public void TestMethod1()
        {
            User user = new User
                {
                    Login = "test2"
                };
            context.Users.Add(user);
            context.SaveChanges();
        }

        [TestMethod]
        public void TestMethod2()
        {
            var test = context.Users.FirstOrDefault(p => p.Login.Contains("test"));
            string test2 ="";
        }
    }
}
