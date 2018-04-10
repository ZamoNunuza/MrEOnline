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
   public class CustomerGetByUsername
    {
        public List<CustomerGetbyUsername> GetCustomerByUserName(string Username)
        {
            Constants constants = new Constants();
            using (IDbConnection connection = new SqlConnection(constants.connectionString))
            {
                const string storedProcedure = "dbo.Customer_GetBy_Username";
                return (List<CustomerGetbyUsername>)connection.Query<CustomerGetbyUsername>(storedProcedure, new { Username = Username }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
