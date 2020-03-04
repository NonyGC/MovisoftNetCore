using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Movisoft.Aplication.Interface
{
    public interface IBaseAppService <ObjectDTO, TEntity> : IDisposable
        where ObjectDTO : class
        where TEntity : class
    {
        object Add(ObjectDTO obj);
        ObjectDTO GetById(int? id);
        IEnumerable<ObjectDTO> GetAll();
        bool Update(ObjectDTO obj);
        bool Remove(ObjectDTO obj);
        IEnumerable<ObjectDTO> GetList(Expression<Func<TEntity, bool>> predicate);
    }
}
