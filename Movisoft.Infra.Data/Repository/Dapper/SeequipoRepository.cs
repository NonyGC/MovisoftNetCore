using Dapper;
using Dommel;
using Microsoft.Extensions.Configuration;
using Movisoft.Domain.Entity;
using Movisoft.Domain.Interfaces.Repository;
using Movisoft.Infra.Data.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Movisoft.Infra.Data.Repository.Dapper
{
    public class SeequipoRepository : DapperRepository<Seequipo>, ISeequipoRepository
    {
        private readonly SeequipoHelper _seequipoHelper;
        public SeequipoRepository(IConfiguration configuration, SeequipoHelper seequipoHelper) : base(configuration)
        {
            _seequipoHelper = seequipoHelper;
        }

        public List<Seequipo> ObtenerListaPorEstado(string estado)
        {
            var sqlQuery = string.Format(_seequipoHelper.SqlObtenerListaEquipos, estado);
            return dbConnection
                .Query<Seequipo, Setipequipo, Setopologia, Siempresa, Seequipo>
                (sqlQuery, (equipo, tequipo, topologia, empresa) =>
                {
                    equipo.Setopologia = topologia;
                    equipo.Siempresa = empresa;
                    equipo.Setipequipo = tequipo;
                    return equipo;
                }, splitOn: "tequicodi,topcodi,emprcodi").AsList();
        }


        public int Save(Seequipo seequipo, IDbConnection connection, IDbTransaction transaction)
        {
            return (int)connection.Insert(seequipo, transaction);
        }
    }
}
