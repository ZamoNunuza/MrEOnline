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
    public class VideoGetAllByStatus
    {
        public List<VideosGetbyStatus> GetAllVideoActive()
        {
            Constants constants = new Constants();
            using (IDbConnection connection = new SqlConnection(constants.connectionString))
            {
                const string storedProcedure = "[dbo].[Video_GetAll]";
                return (List<VideosGetbyStatus>)connection.Query<VideosGetbyStatus>(storedProcedure, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
