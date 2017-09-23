using Dapper;
using Practica.Models;
using Practica.Repositories.Credit;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Practica.Repositories.Dapper.Credit
{
    public class CorporationRepository : Repository<Corporation>, ICorporationRepository
    {
        public CorporationRepository(string connectionString) : base(connectionString)
        {
        }

        public Corporation SearchByName(string corp_name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@corp_name", corp_name);

                return connection.QueryFirst<Corporation>(
                    "dbo.CorporationSearchByName",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
