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
   public class CustomerGetAll
    {
        public List<AllCustomers> GetCustomerAll()
        {
            Constants constants = new Constants();
            using (IDbConnection connection = new SqlConnection(constants.connectionString))
            {
                const string storedProcedure = "[dbo].[Customer_GetAll]";
                return (List<AllCustomers>)connection.Query<AllCustomers>(storedProcedure, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
