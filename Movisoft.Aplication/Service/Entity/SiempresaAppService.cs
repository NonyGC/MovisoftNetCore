using AutoMapper;
using Movisoft.Aplication.DTO;
using Movisoft.Aplication.Interface.Entity;
using Movisoft.Domain.Common;
using Movisoft.Domain.Entity;
using Movisoft.Domain.Interfaces.Repository;
using Movisoft.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Service.Entity
{
    public class SiempresaAppService : BaseAppService<SiempresaDTO, Siempresa>, ISiempresaAppService
    {
        private readonly IUnitOfWorkDapper _uow;
        private readonly ISiempresaRepository _siempresaRepository;
        private readonly ISitipempresaRepository _sitipempresaRepository;
        public SiempresaAppService(IDapperRepository<Siempresa> dapperRepository, IMapper mapper, IUnitOfWorkDapper unitOfWork,
            ISiempresaRepository siempresaRepository, ISitipempresaRepository sitipempresaRepository) 
            : base(dapperRepository, mapper)
        {
            _uow = unitOfWork;
            _siempresaRepository = siempresaRepository;
            _sitipempresaRepository = sitipempresaRepository;
        }

        public bool Insert(SiempresaDTO siempresaDTO, int[] sirelempresas)
        {
            try
            {
                _uow.Begin();

                var siempresa = _mapper.Map<Siempresa>(siempresaDTO);
                var id = _siempresaRepository.Save(siempresa, _uow.Connection, _uow.Transaction);

                if (id.HasValue)
                {
                    foreach (var rel in sirelempresas)
                    {
                        _sitipempresaRepository.Save(new Sirelempresa { Emprcodi = id.Value, Tempcodi = rel }, _uow.Connection, _uow.Transaction);
                    }
                    _uow.Commit();
                }
                {
                    _uow.Rollback();
                }
            }
            catch (Exception e)
            {
                _uow.Rollback();
            }
            finally
            {
                _uow.Dispose();
            }

            return true;
        }

        public IEnumerable<SiempresaDTO> GetListActivo()
        {
            return GetList(x => x.Emprestado == ConstantesBase.Activo);
        }
    }
}
