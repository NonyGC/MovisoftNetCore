using AutoMapper;
using Movisoft.Aplication.DTO;
using Movisoft.Aplication.Interface.Entity;
using Movisoft.Domain.Entity;
using Movisoft.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movisoft.Aplication.Service.Entity
{
    public class SetopologiaAppService : BaseAppService<SetopologiaDTO, Setopologia>, ISetopologiaAppService
    {
        private readonly ISetopologiaRepository _setopologiaRepository;
        public SetopologiaAppService(IDapperRepository<Setopologia> dapperRepository, IMapper mapper,ISetopologiaRepository setopologiaRepository) 
            : base(dapperRepository, mapper)
        {
            _setopologiaRepository = setopologiaRepository;
        }

        public bool Actualizar(SetopologiaDTO setopologiaDTO)
        {
            var topologia = GetById(setopologiaDTO.Topcodi);
            topologia.Actualizar(setopologiaDTO.Topnombre);

            return Update(topologia);
        }

        public bool ActualizarAEstadoInactivo(int id)
        {
            var topologia = GetById(id);
            topologia.Inactivo();

            return Update(topologia);
        }

        public int? Insertar(SetopologiaDTO setopologiaDTO)
        {
            setopologiaDTO.Activo();

            return (int?)Add(setopologiaDTO);
        }

        public List<SetopologiaDTO> ObtenerListaPorEstado(string estado)
        {
            var lstTopologia = GetList(x => x.Topestado == estado);
            foreach (var item in lstTopologia)
            {
                item.CompletarEstado();
            }

            return lstTopologia.ToList();
        }
    }
}
