using Hobby.DTO;
using Hobby.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Entities
{
    public class UserPermission : UserPermissionDTO, IEntity
    {
        public virtual Permission Permission { get; set; }

        public virtual User User { get; set; }
    }
}
