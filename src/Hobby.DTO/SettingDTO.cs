using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.DTO
{
    public class SettingDTO
    {
        public virtual decimal Id { get; set; }

        public virtual decimal IdUser { get; set; }

        public virtual string Name { get; set; }

        public virtual bool Value { get; set; }

        public virtual DateTime? CreateDate { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}
