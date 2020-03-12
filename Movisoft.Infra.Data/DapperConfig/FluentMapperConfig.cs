using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Movisoft.Infra.Data.Mappings.Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Infra.Data.DapperConfig
{
    public class FluentMapperConfig
    {
        public static void RegisterMappings()
        {
            FluentMapper.Initialize(x => 
            {
                x.AddMap(new SeequipoMap());
                x.AddMap(new SetipequipoMap());
                x.AddMap(new SetopologiaMap());
                x.AddMap(new SiempresaMap());
                x.AddMap(new SitipempresaMap());
                x.ForDommel();
            });
        }
    }
}
