using Hobby.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Add(TEntity item)
        {
            DbSet.Add(item);
        }

        public virtual TEntity Single(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Where(filter).Single();
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
