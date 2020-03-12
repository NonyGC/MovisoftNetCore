using AutoMapper;
using Movisoft.Aplication.DTO;
using Movisoft.Aplication.Interface.Entity;
using Movisoft.Domain.Entity;
using Movisoft.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Service.Entity
{
    public class SitipempresaAppService : BaseAppService<SitipempresaDTO, Sitipempresa>, ISitipempresaAppService
    {
        public SitipempresaAppService(IDapperRepository<Sitipempresa> dapperRepository, IMapper mapper) : base(dapperRepository, mapper)
        {
        }
    }
}
