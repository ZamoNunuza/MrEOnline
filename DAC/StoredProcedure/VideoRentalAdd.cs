using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MrEOnline.Models;

namespace DAC.StoredProcedure
{
    public class VideoRentalAdd
    {
        public VideoRental AddRentalVideo(string VideoID, string CustomerName, string CustomerPhone, string Title)
        {
            Constants Constants = new Constants();
            using (IDbConnection connection = new SqlConnection(Constants.connectionString))
            {
                const string storedProcedure = "dbo.Video_Rental_Add";
                return (VideoRental)connection.QueryFirst<VideoRental>(storedProcedure, new { VideoID = VideoID, CustomerUsername = CustomerName, CustomerPhone = CustomerPhone, Title = Title}, commandType: CommandType.StoredProcedure);
            }

        }
    }
}
