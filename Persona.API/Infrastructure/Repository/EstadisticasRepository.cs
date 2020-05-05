using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Persona.API.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Persona.API.Infrastructure.Repository
{
    public class EstadisticasRepository : IEstadisticaRepository
    {
        private readonly IConfiguration _config;

        public EstadisticasRepository(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("myDb1"));
            }
        }
        public async Task<EstadisticasDTO> GetEstadisticas()
        {

            using (IDbConnection conn = Connection)
            {
                string sQuery = @"SELECT COUNT( IdDoc ) *100 / (select COUNT( IdDoc ) from persona )  AS  Porcentaje_Argentinos ,
                                 (SELECT count(IdDoc)  FROM Persona where sexo = 'M' and IdPais = 12) AS Cantidad_Hombres,
                                 ( SELECT count(IdDoc) FROM Persona where sexo = 'F' and IdPais = 12 ) AS Cantidad_Mujeres
                                FROM Persona where IdPais = 12 ";
                conn.Open();
                var result = await conn.QueryAsync<EstadisticasDTO>(sQuery);
                return result.FirstOrDefault();
            }


        }
    }
}
