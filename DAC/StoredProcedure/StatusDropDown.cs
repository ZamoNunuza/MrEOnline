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
    public class StatusDropDown
    {
        public List<Status> GetStatus()
        {
            Constants constants = new Constants();
            using (IDbConnection connection = new SqlConnection(constants.connectionString))
            {
                const string storedProcedure = "[dbo].[Status_DropDown]";
                return (List<Status>)connection.Query<Status>(storedProcedure, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
