using Dapper;
using Practica.Models;
using Practica.Repositories.Credit;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Practica.Repositories.Dapper.Credit
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(string connectionString) : base(connectionString)
        {
        }

        public Member SearchByNames(string firstName, string lastName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@firstname", firstName);
                parameters.Add("@lastname", lastName);

                return connection.QueryFirst<Member>(
                    "dbo.MemberSearchByNames",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
