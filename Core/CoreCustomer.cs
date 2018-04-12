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
    public class CoreCustomer
    {
        public CustomerDashbordViewModel VideoView()
        {
            VideoGetAllByStatus repos = new VideoGetAllByStatus();
            List<VideosGetbyStatus> model = new List<VideosGetbyStatus>();

            CustomerDashbordViewModel viewModel = new CustomerDashbordViewModel();

            model = repos.GetAllVideoActive();
            viewModel.AllVideosView = model;
            return viewModel;
        }
    }
}
