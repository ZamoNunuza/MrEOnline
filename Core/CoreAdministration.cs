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
    public class CoreAdministration
    {
        public AdminDashboardViewModel GetStatusDropdown()
        {
            StatusDropDown dac = new StatusDropDown();
            List<Status> model = new List<Status>();

            AdminDashboardViewModel viewModel = new AdminDashboardViewModel();

            model = dac.GetStatus();
            viewModel.DropdownStatus = model;
            return viewModel;
        }

        public AdminDashboardViewModel UpdateVideos(string VideoID, string Title, string Description, string Genre, string RentalPrice, string Status)
        {
            AdminDashboardViewModel viewModel = new AdminDashboardViewModel();
            VideoUpdate dac = new VideoUpdate();
            List<UpdateVideo> model = new List<UpdateVideo>();

            model = dac.UpdateVideoList(VideoID, Title, Description, Genre, RentalPrice, Status);
            viewModel.VideoListUpdate = model;
            return viewModel;
        }
    }
}
