using AutoMapper;
using Movisoft.Aplication.DTO;
using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Seequipo, SeequipoDTO>();
            CreateMap<Setipequipo, SetipequipoDTO>();
            CreateMap<Setopologia, SetopologiaDTO>();
            CreateMap<Siempresa, SiempresaDTO>();
            CreateMap<Sitipempresa, SitipempresaDTO>();
        }
    }
}
