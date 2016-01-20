using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.DTO
{
    public class UserDTO
    {
        public virtual decimal Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual DateTime? CreateDate { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}
