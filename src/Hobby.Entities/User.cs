using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby.DTO;
using Hobby.Entities.Interface;

namespace Hobby.Entities
{
    public class User : UserDTO, IEntity
    {
        public virtual ICollection<Setting> Settings { get; set; }

        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
