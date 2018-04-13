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
    public class ReturnVideoUpdate
    {
        public VideoUpdateReturn GetVideosReturn(string RentalID, string VideoID)
        {
            Constants constants = new Constants();
            using (IDbConnection connection = new SqlConnection(constants.connectionString))
            {
                const string storedProcedure = "dbo.Return_Video";
                return (VideoUpdateReturn)connection.QueryFirst<VideoUpdateReturn>(storedProcedure, new { RentalID = RentalID, VideoID = VideoID}, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
