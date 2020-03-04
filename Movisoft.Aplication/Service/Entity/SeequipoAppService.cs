using AutoMapper;
using Movisoft.Aplication.DTO;
using Movisoft.Aplication.Interface;
using Movisoft.Aplication.Interface.Entity;
using Movisoft.Domain.Entity;
using Movisoft.Domain.Interfaces.Repository;
using Movisoft.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Service.Entity
{
    public class SeequipoAppService : BaseAppService<SeequipoDTO, Seequipo>, ISeequipoAppService
    {
        private readonly ISeequipoRepository _seequipoRepository;
        private readonly ISeequipoService _seequipoService;

        public SeequipoAppService(ISeequipoRepository seequipoRepository, ISeequipoService seequipoService, IDapperRepository<Seequipo> dapperRepository, IMapper mapper)
            : base(dapperRepository, mapper)
        {
            _seequipoRepository = seequipoRepository;
            _seequipoService = seequipoService;
        }

        public bool Actualizar(SeequipoDTO seequipoDTO)
        {
            var equipo = GetById(seequipoDTO.Equicodi);
            equipo.Actualizar(seequipoDTO.Topcodi, seequipoDTO.Tequicodi, seequipoDTO.Emprcodi, seequipoDTO.Equinombre, seequipoDTO.Equiabrev);
            return Update(equipo);
        }

        public bool ActualizarAEstadoInactivo(int id)
        {
            var equipo = GetById(id);
            equipo.Inactivo();
            return Update(equipo);
        }

        public int? Insertar(SeequipoDTO seequipoDTO)
        {
            var seequipo = _mapper.Map<Seequipo>(seequipoDTO);
            seequipoDTO.Activo();
            return (int?)_seequipoRepository.Add(seequipo);
        }

        public List<SeequipoDTO> ObtenerListaPorEstado(string estado)
        {
            var lstDPPersona = _mapper.Map<List<SeequipoDTO>>(_seequipoRepository.ObtenerListaPorEstado(estado));
            return lstDPPersona;
        }

        public int? Save(SeequipoDTO seequipoDTO)
        {
            var seequipo = _mapper.Map<Seequipo>(seequipoDTO);
            return _seequipoService.Save(seequipo);
        }

    }
}
