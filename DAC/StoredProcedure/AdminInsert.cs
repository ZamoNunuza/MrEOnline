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
   public class AdminInsert
    {
        public AdministrationInsert adminInesrt(string AdminName, string EmailAddress, string AdminPassword)
        {
            Constants constants = new Constants();
            using (IDbConnection connection = new SqlConnection(constants.connectionString))
            {
                const string storedProcedure = "dbo.Customer_Insert";
                return (AdministrationInsert)connection.QueryFirst<AdministrationInsert>(storedProcedure, new { AdminName = AdminName, EmailAddress = EmailAddress, AdminPassword = AdminPassword}, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
