using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby.Entities;

namespace Hobby.Data.ConfigurationEntities
{   
    public partial class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");

            Property(e => e.Id).HasPrecision(18, 0);
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.FirstName).IsRequired();

            Property(e => e.LastName).IsRequired();

            Property(e => e.Email).IsRequired();

            Property(e => e.CreateDate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            Property(e => e.RowVersion)
                 .IsFixedLength()
                 .HasColumnType("timestamp")
                 .HasMaxLength(8)
                 .IsRowVersion();

            HasMany(e => e.Settings)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            HasMany(e => e.UserPermissions)
               .WithRequired(e => e.User)
               .HasForeignKey(e => e.IdPermission)
               .WillCascadeOnDelete(false);
        }
    }
}
