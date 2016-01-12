namespace Hobby.Data
{
    using System;
    using System.Data.Entity;
    using System.Reflection;
    using Hobby.Data.ConfigurationEntities;
    using Hobby.Entities;

    public class ModelEntities : DbContext
    {
        public ModelEntities()
            : base("HobbyDev")
        {           
            SetContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(GetType())); Current Assembly
            // base.OnModelCreating(modelBuilder);
            // modelBuilder.Configurations.Add(new UserConfiguration());Pojedyncze dodanie
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(typeof(ModelEntities).Assembly);           
        }

        private void SetContext()
        {
            Database.SetInitializer<ModelEntities>(null);

            // ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 120;
            // this.Configuration.LazyLoadingEnabled = true;
        }
    }
}
