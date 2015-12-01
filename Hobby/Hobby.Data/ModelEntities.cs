using Hobby.Data.Infrastructure;
using Hobby.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Data
{
    public class ModelEntities : ModelEntitiesContext
    {
        public ModelEntities()
            : base("HobbyDev")
        {
            SetContext();
        }

        void SetContext()
        {
            Database.SetInitializer<ModelEntities>(null);

            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 120;
            this.Configuration.LazyLoadingEnabled = true;
        }
    }
}
