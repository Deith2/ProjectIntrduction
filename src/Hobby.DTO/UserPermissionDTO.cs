using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.DTO
{
    public class UserPermissionDTO
    {
        public decimal Id { get; set; }

        public virtual decimal IdUser { get; set; }

        public virtual decimal IdPermission { get; set; }

        public virtual DateTime? CreateDate { get; set; }

        public virtual DateTime? LastModifyDate { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}
