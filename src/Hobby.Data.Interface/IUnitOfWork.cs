using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hobby.Entities;

namespace Hobby.Data.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }

        IRepository<Setting> Settings { get; }

        IRepository<Category> Categories { get; }

        IRepository<Permission> Permissions { get; }

        IRepository<UserPermission> UserPermissions { get; }

        void Save();
    }
}
