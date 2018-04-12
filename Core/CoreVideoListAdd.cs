using DAC.StoredProcedure;
using MrEOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Core
{
    public class CoreVideoListAdd
    {
        public AdminDashboardViewModel InsertVideo(string Title, string Description, string Genre, string RentalPrice)
        {
            AdminDashboardViewModel viewModel = new AdminDashboardViewModel();
            VideoListAdd repos = new VideoListAdd();
            List<AddVideo> model = new List<AddVideo>();

            model = repos.AddVideoList(Title, Description, Genre, RentalPrice);
            viewModel.VideoListInsert = model;
            return viewModel;
        }
        
    }
}
