using Hobby.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Data.EntitiesConfiguration
{
    public partial class CategorieConfiguration : EntityTypeConfiguration<Category>
    {
        public CategorieConfiguration()
        {
            ToTable("Categories");

            Property(e => e.Id).HasPrecision(18, 0);
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name).IsRequired();

            Property(e => e.CreateDate)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            Property(e => e.RowVersion)
                 .IsFixedLength()
                 .HasColumnType("timestamp")
                 .HasMaxLength(8)
                 .IsRowVersion();
        }
    }
}
