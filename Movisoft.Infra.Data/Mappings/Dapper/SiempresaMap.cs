using Dapper.FluentMap.Dommel.Mapping;
using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Infra.Data.Mappings.Dapper
{
    public class SiempresaMap : DommelEntityMap<Siempresa>
    {
        public SiempresaMap()
        {
            ToTable("si_empresa");
            Map(p => p.Emprcodi).IsKey();
        }
    }
}
