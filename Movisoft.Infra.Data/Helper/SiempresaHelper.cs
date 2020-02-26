using Movisoft.CrossCutting.Common.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Infra.Data.Helper
{
    public class SiempresaHelper : HelperBase
    {
        public SiempresaHelper() : base(Queries.Siempresa)
        {
        }

        public string SqlObtenerListSelectItem => GetSqlXml("ObtenerListSelectItem"); 
    }
}
