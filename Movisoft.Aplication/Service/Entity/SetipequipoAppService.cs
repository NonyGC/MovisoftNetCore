using AutoMapper;
using Movisoft.Aplication.DTO;
using Movisoft.Domain.Entity;
using Movisoft.Domain.Interfaces.Repository;
using Movisoft.Aplication.Interface.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Movisoft.Aplication.Service.Entity
{
    public class SetipequipoAppService : BaseAppService<SetipequipoDTO, Setipequipo>, ISetipequipoAppService
    {
        public SetipequipoAppService(IDapperRepository<Setipequipo> dapperRepository, IMapper mapper) 
            : base(dapperRepository, mapper)
        {
        }

        public bool Actualizar(SetipequipoDTO setipequipoDTO)
        {
            var equipo = GetById(setipequipoDTO.Tequicodi);
            equipo.Actualizar(setipequipoDTO.Tequinomb);
            return Update(equipo);
        }

        public bool ActualizarAEstadoInactivo(int id)
        {
            var tipoequipo = GetById(id);
            tipoequipo.Inactivo();
            return Update(tipoequipo);
        }

        public int? Insertar(SetipequipoDTO setipequipoDTO)
        {
            setipequipoDTO.Activo();
            return (int?)Add(setipequipoDTO);
        }

        public List<SetipequipoDTO> ObtenerListaPorEstado(string estado)
        {
            var lstTipoequipo = GetList(x => x.Tequiestado == estado);
            foreach (var item in lstTipoequipo)
            {
                item.CompletarEstado();
            }

            return _mapper.Map<List<SetipequipoDTO>>(lstTipoequipo);
        }
    }
}
