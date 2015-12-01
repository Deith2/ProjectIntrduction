using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Entities
{
    public class User
    {
        public virtual decimal Id { get; set; }
        public virtual string Login { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}
