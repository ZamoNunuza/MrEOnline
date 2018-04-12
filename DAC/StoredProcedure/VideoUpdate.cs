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
    public class VideoUpdate
    {
        public UpdateVideo UpdateVideoList(string VideoID, string Title, string Description, string Genre, string RentalPrice, string Status)
        {
            Constants Constants = new Constants();
            using (IDbConnection connection = new SqlConnection(Constants.connectionString))
            {
                const string storedProcedure = "dbo.Video_Update";
                return (UpdateVideo)connection.QueryFirst<UpdateVideo>(storedProcedure, new { VideoID= VideoID, Title = Title, Description = Description, Genre = Genre, RentalPrice = RentalPrice, Status = Status }, commandType: CommandType.StoredProcedure);
            }

        }
    }
}
