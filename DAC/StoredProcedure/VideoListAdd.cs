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
    public class VideoListAdd
    {
        public List<AddVideo> AddVideoList(string Title, string Description, string Genre, string RentalPrice)
        {
            Constants Constants = new Constants();
            using (IDbConnection connection = new SqlConnection(Constants.connectionString))
            {
                const string storedProcedure = "dbo.Video_List_Add";
                return (List<AddVideo>)connection.Query<AddVideo>(storedProcedure, new { Title = Title, Description = Description, Genre = Genre, RentalPrice = RentalPrice}, commandType: CommandType.StoredProcedure);
            }

        }
    }
}
