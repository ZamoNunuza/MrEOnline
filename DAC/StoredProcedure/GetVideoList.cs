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
    public class GetVideoList
    {
        public List<GetAllVideos> getVideolists()
        {

            Constants constants = new Constants();
            using (IDbConnection connection = new SqlConnection(constants.connectionString))
            {
                const string storedProcedure = "dbo.Video_GetAll";
                return (List<GetAllVideos>)connection.Query<GetAllVideos>(storedProcedure, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
