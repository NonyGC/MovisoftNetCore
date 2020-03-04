using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Movisoft.Domain.Interfaces.Repository
{
    public interface IDapperRepository<TEntity> : IDisposable where TEntity : class
    {
        object Add(TEntity obj);
        TEntity GetById(int? id);
        IEnumerable<TEntity> GetAll();
        bool Update(TEntity obj);
        bool Remove(TEntity obj);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
    }
}
