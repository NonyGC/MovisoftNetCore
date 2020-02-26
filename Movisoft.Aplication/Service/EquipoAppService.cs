using AutoMapper;
using Movisoft.Aplication.DTO;
using Movisoft.Aplication.Interface;
using Movisoft.Domain.Entity;
using Movisoft.Domain.Interfaces.Repository;
using Movisoft.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Service
{
    public class EquipoAppService : BaseAppService<SeequipoDTO, Seequipo>, IEquipoAppService
    {
        public readonly ISeequipoRepository _seequipoRepository;
        public readonly ISeequipoService _seequipoService;

        public EquipoAppService(ISeequipoRepository seequipoRepository,ISeequipoService seequipoService, IDapperRepository<Seequipo> dapperRepository, IMapper mapper)
            : base(dapperRepository, mapper)
        {
            _seequipoRepository = seequipoRepository;
            _seequipoService = seequipoService;
        }

        public List<SeequipoDTO> ObtenerListaEquipos()
        {
            var lstDPPersona = _mapper.Map<List<SeequipoDTO>>(_seequipoRepository.ObtenerListaEquipos());
            return lstDPPersona;
        }

        public int? Save(SeequipoDTO seequipoDTO)
        {
            var seequipo = _mapper.Map<Seequipo>(seequipoDTO);
            return _seequipoService.Save(seequipo);
        }
    }
}
