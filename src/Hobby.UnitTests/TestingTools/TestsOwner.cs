using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.UnitTests.TestingTools
{
    public class TestsOwner : Attribute
    {
        private string Owner { get; set; }

        public TestsOwner(string owner)
        {
            this.Owner = owner;
        }
    }
}
