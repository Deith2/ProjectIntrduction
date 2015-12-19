using Hobby.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby.Data;
using Hobby.Entities;

namespace Hobby.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ModelEntities _context;
        private bool _dispose = false;

        public UnitOfWork()
        {
            _context = new ModelEntities();
        }

        public IRepository<User> Users
        {
            get { return GetRepository<User>(); }
        }

        protected IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var repository = new GenericRepository<TEntity>(_context);
            return repository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_dispose)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _dispose = true;
        }
    }
}
