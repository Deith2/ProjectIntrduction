using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Hobby.Data.Interface
{
    public interface IRepository<TEntity> : IDisposable
    {
        void Add(TEntity item);

        TEntity GetById(object id);

        TEntity Single(Expression<Func<TEntity, bool>> filter);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter);

        bool Any();

        bool Any(Expression<Func<TEntity, bool>> filter);

        IQueryable<TEntity> All();

        IQueryable<TEntity> All(Expression<Func<TEntity, bool>> filter);
    }
}
