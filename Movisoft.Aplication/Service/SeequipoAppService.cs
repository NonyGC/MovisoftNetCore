using AutoMapper;
using Movisoft.Aplication.DTO;
using Movisoft.Aplication.Interface;
using Movisoft.Domain.Entity;
using Movisoft.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Service
{
    public class SeequipoAppService : BaseAppService<SeequipoDTO, Seequipo>, ISeequipoAppService
    {
        public readonly ISeequipoRepository _seequipoRepository;

        public SeequipoAppService(ISeequipoRepository seequipoRepository, IDapperRepository<Seequipo> dapperRepository, IMapper mapper)
            : base(dapperRepository, mapper)
        {
            _seequipoRepository = seequipoRepository;
        }

        public List<SeequipoDTO> ObtenerListaEquipos()
        {
            var lstDPPersona = _mapper.Map<List<SeequipoDTO>>(_seequipoRepository.ObtenerListaEquipos());
            return lstDPPersona;
        }
    }
}
