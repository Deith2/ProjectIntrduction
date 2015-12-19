using Hobby.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hobby.Data.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }

        void Save();
    }
}
