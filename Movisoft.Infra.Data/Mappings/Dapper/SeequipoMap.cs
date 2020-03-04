using Dapper.FluentMap.Dommel.Mapping;
using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Infra.Data.Mappings.Dapper
{
    public class SeequipoMap : DommelEntityMap<Seequipo>
    {
        public SeequipoMap()
        {
            ToTable("se_equipo");
            Map(p => p.Equicodi).IsKey().IsIdentity();
        }
    }
}
