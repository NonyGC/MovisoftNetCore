using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.AutoMapper
{
    public class AutoMapperConfig
    {
        public static Type[] RegisterMappings()
        {
            return new Type[]
            {
                typeof(DomainToViewModelMappingProfile),
                typeof(ViewModelToDomainMappingProfile),
                typeof(BiDirectionalViewModelDomain)
            };
        }
    }
}
