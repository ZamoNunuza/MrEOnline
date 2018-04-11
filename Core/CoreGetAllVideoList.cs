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
    public class CoreGetAllVideoList
    {
        public AdminDashboardViewModel GetListVideo()
        {
            GetVideoList repos = new GetVideoList();
            AdminDashboardViewModel viewModel = new AdminDashboardViewModel();
            List<GetAllVideos> model = new List<GetAllVideos>();

            model = repos.getVideolists();
            viewModel.allVideo = model;
            return viewModel;


        }
    }
}
