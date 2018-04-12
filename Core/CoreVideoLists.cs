
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
    public class CoreVideoLists
    {
        public AdminDashboardViewModel VideoView()
        {
            VideoGetAll repos = new VideoGetAll();
            List<AllVideos> model = new List<AllVideos>();

            AdminDashboardViewModel viewModel = new AdminDashboardViewModel();

            model = repos.GetAllVideo();
            viewModel.VideoView = model;
            return viewModel;
        }
    }
}
