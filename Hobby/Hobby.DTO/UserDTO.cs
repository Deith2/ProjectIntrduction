using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.DTO
{
    public class UserDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual decimal Id { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual DateTime? CreateDate { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}
