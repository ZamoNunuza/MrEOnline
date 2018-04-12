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
    public class CustomerGetByID
    {
        public List<CustomerGetbyID> GetCustomerByID(string CustomerID)
        {
            Constants constants = new Constants();
            using (IDbConnection connection = new SqlConnection(constants.connectionString))
            {
                const string storedProcedure = "dbo.Customer_GetBy_ID";
                return (List<CustomerGetbyID>)connection.Query<CustomerGetbyID>(storedProcedure, new { CustomerID = CustomerID }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
