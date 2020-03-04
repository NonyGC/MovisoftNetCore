using AutoMapper;
using Movisoft.Aplication.Interface;
using Movisoft.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Movisoft.Aplication.Service
{
    public class BaseAppService<ObjectDTO, TEntity> : IBaseAppService<ObjectDTO, TEntity>
        where ObjectDTO : class
        where TEntity : class
    {
        private readonly IDapperRepository<TEntity> _dapperRepository;
        protected readonly IMapper _mapper;
        public BaseAppService(IDapperRepository<TEntity> dapperRepository, IMapper mapper)
        {
            _dapperRepository = dapperRepository;
            _mapper = mapper;
        }

        public object Add(ObjectDTO obj)
        {
           return _dapperRepository.Add(_mapper.Map<TEntity>(obj));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ObjectDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<ObjectDTO>>(_dapperRepository.GetAll()).AsEnumerable();
        }

        public ObjectDTO GetById(int? id)
        {
            return _mapper.Map<ObjectDTO>(_dapperRepository.GetById(id));
        }

        public bool Remove(ObjectDTO obj)
        {
            return _dapperRepository.Remove(_mapper.Map<TEntity>(obj));
        }

        public bool Update(ObjectDTO obj)
        {
            return _dapperRepository.Update(_mapper.Map<TEntity>(obj));
        }

        public IEnumerable<ObjectDTO> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return _mapper.Map<IEnumerable<ObjectDTO>>(_dapperRepository.GetList(predicate)).AsEnumerable();
        }
    }
}
