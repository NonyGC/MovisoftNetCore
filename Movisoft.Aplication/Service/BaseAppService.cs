using AutoMapper;
using Movisoft.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movisoft.Aplication.Service
{
    public class BaseAppService<ObjectDTO, TEntity> 
        where ObjectDTO : class 
        where TEntity : class
    {
        public readonly IDapperRepository<TEntity> _dapperRepository;
        public readonly IMapper _mapper;
        public BaseAppService(IDapperRepository<TEntity> dapperRepository, IMapper mapper)
        {
            _dapperRepository = dapperRepository;
            _mapper = mapper;
        }
        public void Add(ObjectDTO obj)
        {
            throw new NotImplementedException();
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

        public void Remove(ObjectDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Update(ObjectDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
