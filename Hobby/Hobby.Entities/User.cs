﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby.Entities.Interface;

namespace Hobby.Entities
{
    public class User : IEntity
    {
        public virtual decimal Id { get; set; }

        public virtual string Login { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}
