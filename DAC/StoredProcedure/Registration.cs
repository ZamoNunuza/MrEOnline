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
    public class Registration
    {
        public RegistrationInsert registrationInesrt(string CustomerName, string Address, string PhoneNumber, string Password, string EmailAddress)
        {
            Constants constants = new Constants();
            using (IDbConnection connection = new SqlConnection(constants.connectionString))
            {
                const string storedProcedure = "dbo.Customer_Insert";
                return (RegistrationInsert)connection.QueryFirst<RegistrationInsert>(storedProcedure, new { CustomerName = CustomerName, Address = Address, PhoneNumber = PhoneNumber, Password = Password, EmailAddress = EmailAddress }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
