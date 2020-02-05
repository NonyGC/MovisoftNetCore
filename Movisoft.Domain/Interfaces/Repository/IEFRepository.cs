using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movisoft.Domain.Interfaces.Repository
{
    public interface IEFRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}
