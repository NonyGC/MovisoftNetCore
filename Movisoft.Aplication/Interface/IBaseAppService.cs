using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Interface
{
    public interface IBaseAppService<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int? id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
