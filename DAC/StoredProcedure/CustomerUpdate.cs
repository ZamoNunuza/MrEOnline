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
    public class CustomerUpdate
    {
        public UpdateCustomer UpdateCustomerList(string CustomerID, string CustomerName, string Address, string PhoneNumber, string Password, string EmailAddress , string Status)
        {
            Constants Constants = new Constants();
            using (IDbConnection connection = new SqlConnection(Constants.connectionString))
            {
                const string storedProcedure = "[dbo].[Customer_Update]";
                return (UpdateCustomer)connection.QueryFirst<UpdateCustomer>(storedProcedure, new {CustomerID = CustomerID, CustomerName = CustomerName, Address = Address, PhoneNumber = PhoneNumber, Password = Password, Status = Status, EmailAddress = EmailAddress }, commandType: CommandType.StoredProcedure);
            }

        }
    }
}
