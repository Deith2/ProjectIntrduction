using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby.DTO;
using Hobby.Entities.Interface;

namespace Hobby.Entities
{
    public class Setting : SettingDTO, IEntity
    {
        public virtual User User { get; set; }
    }
}
