using Dapper;
using MrEOnline.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC.StoredProcedure
{
    public class AdminGetByUsername
    {
        public List<AdminGetbyUsername> GetAdminByUserName(string Username)
        {
            Constants constants = new Constants();
            using (IDbConnection connection = new SqlConnection(constants.connectionString))
            {
                const string storedProcedure = "dbo.Admin_GetBy_Username";
                return (List<AdminGetbyUsername>)connection.Query<AdminGetbyUsername>(storedProcedure, new { Username = Username }, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
