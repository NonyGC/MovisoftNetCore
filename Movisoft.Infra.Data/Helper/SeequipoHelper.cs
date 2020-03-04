using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Infra.Data.Helper
{
    public class SeequipoHelper: HelperBase
    {
        public SeequipoHelper() : base(Queries.Seequipo)
        {
        }
        public string SqlObtenerListaEquipos => GetSqlXml("ObtenerListaEquipos");
    }
}
