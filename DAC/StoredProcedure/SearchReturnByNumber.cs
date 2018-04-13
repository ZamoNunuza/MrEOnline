using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MrEOnline.Models;

namespace DAC.StoredProcedure
{
    public class SearchReturnByNumber
    {
        public List<VideoReturnByNumber> GetVideoBuySearch (string PhoneNumber)
        {
            Constants constants = new Constants();
            using (IDbConnection connection = new SqlConnection(constants.connectionString))
            {
                const string storedProcedure = "dbo.Video_Return_ByNumber";
                return (List<VideoReturnByNumber>)connection.Query<VideoReturnByNumber>(storedProcedure, new { PhoneNumber = PhoneNumber }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
