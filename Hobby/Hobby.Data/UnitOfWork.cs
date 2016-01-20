using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby.Data;
using Hobby.Data.Interface;
using Hobby.Entities;

namespace Hobby.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        private readonly ModelEntities _context;
        private bool _disposed = false;

        public UnitOfWork()
        {
            _context = new ModelEntities();
        }      

        public IRepository<User> Users
        {
            get { return GetRepository<User>(); }
        }

        public IRepository<Setting> Settings
        {
            get { return GetRepository<Setting>(); }
        }

        public IRepository<Categorie> Categories  
        {
            get { return GetRepository<Categorie>(); }
        }

        public IRepository<Permission> Permissions
        {
            get { return GetRepository<Permission>(); }
        }

        public IRepository<UserPermission> UserPermissions
        {
            get { return GetRepository<UserPermission>(); }
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

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this._disposed = true;
        }

        protected IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            var repository = new GenericRepository<TEntity>(_context);

            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }
    }
}
