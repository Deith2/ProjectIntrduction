using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Entities.Interface
{
    public interface IEntity
    {
        decimal Id { get; set; }

        DateTime? CreateDate { get; set; }

        byte[] RowVersion { get; set; }
    }
}
