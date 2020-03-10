using AutoMapper;
using Movisoft.Aplication.DTO;
using Movisoft.Aplication.Interface;
using Movisoft.Aplication.Interface.Entity;
using Movisoft.Domain.Entity;
using Movisoft.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;

namespace Movisoft.Aplication.Service.Entity
{
    public class SeequipoAppService : BaseAppService<SeequipoDTO, Seequipo>, ISeequipoAppService
    {
        private readonly ISeequipoRepository _seequipoRepository;

        public SeequipoAppService(ISeequipoRepository seequipoRepository, IDapperRepository<Seequipo> dapperRepository, IMapper mapper)
            : base(dapperRepository, mapper)
        {
            _seequipoRepository = seequipoRepository;
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
            throw new NotImplementedException();
        }
    }
}
