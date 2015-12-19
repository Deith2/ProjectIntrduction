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

        TEntity Single(Expression<Func<TEntity, bool>> filter);

        TEntity GetById(object id);
    }
}
