using Dapper.FluentMap.Dommel.Mapping;
using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Infra.Data.Mappings.Dapper
{
    public class SetopologiaMap : DommelEntityMap<Setopologia>
    {
        public SetopologiaMap()
        {
            ToTable("se_topologia");
            Map(p => p.Topcodi).IsKey();
        }
    }
}
