using Dapper.FluentMap.Dommel.Mapping;
using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Infra.Data.Mappings.Dapper
{
    public class SetipequipoMap : DommelEntityMap<Setipequipo>
    {
        public SetipequipoMap()
        {
            ToTable("se_tipequipo");
            Map(p => p.Tequicodi).IsKey();
        }
    }
}
