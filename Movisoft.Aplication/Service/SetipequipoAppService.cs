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
    public class SetipequipoAppService : BaseAppService<SetipequipoDTO, Setipequipo>, ISetipequipoAppService
    {
        public SetipequipoAppService(IDapperRepository<Setipequipo> dapperRepository, IMapper mapper) 
            : base(dapperRepository, mapper)
        {
        }
    }
}
