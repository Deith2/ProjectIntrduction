using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hobby.Data.Interface;

namespace Hobby.Data
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ModelEntities _context { get; set; }

        internal virtual IDbSet<TEntity> DbSet
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }

        public GenericRepository(ModelEntities context)
        {
            _context = context;
        }      

        public virtual void Add(TEntity item)
        {
            DbSet.Add(item);
        }

        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity Single(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Where(filter).Single();
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Where(filter).FirstOrDefault();
        }

        public virtual bool Any()
        {
            return DbSet.Any();
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Any(filter);
        }

        public virtual IQueryable<TEntity> All()
        {
            return DbSet.AsQueryable();
        }

        public virtual IQueryable<TEntity> All(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Where(filter);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _context != null)
            {
                _context.Dispose();
            }
        }
    }
}
