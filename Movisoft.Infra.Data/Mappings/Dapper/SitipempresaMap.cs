using Dapper.FluentMap.Dommel.Mapping;
using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Infra.Data.Mappings.Dapper
{
    public class SitipempresaMap : DommelEntityMap<Sitipempresa>
    {
        public SitipempresaMap()
        {
            ToTable("si_tipempresa");
            Map(x => x.Tempcodi).IsKey().IsIdentity();
        }
    }
}
