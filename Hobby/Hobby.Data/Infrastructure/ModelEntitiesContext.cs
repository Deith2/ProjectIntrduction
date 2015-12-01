using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Data.Infrastructure
{
    public abstract class ModelEntitiesContext : DbContext
    {
        public ModelEntitiesContext(string connect) : base (connect)
        {
        } 
    }
}
