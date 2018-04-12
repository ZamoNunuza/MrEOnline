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
    public class VideoGetByID
    {
        public List<VideoGetbyID> GetVideobyID(string VideoID)
        {
            Constants constants = new Constants();
            using (IDbConnection connection = new SqlConnection(constants.connectionString))
            {
                const string storedProcedure = "dbo.Video_GetBy_ID";
                return (List<VideoGetbyID>)connection.Query<VideoGetbyID>(storedProcedure, new { VideoID = VideoID }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
