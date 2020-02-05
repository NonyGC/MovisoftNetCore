using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Domain.Interfaces.Repository
{
    public interface IDapperRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int? id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
