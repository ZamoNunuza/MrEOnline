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
            UpdateVideo model = new UpdateVideo();

            model = dac.UpdateVideoList(VideoID, Title, Description, Genre, RentalPrice, Status);
            viewModel.VideoListUpdate = model;
            return viewModel;
        }

        public AdminDashboardViewModel UpdateCustomers(string CustomerID, string CustomerName, string Address, string PhoneNumber, string Password, string EmailAddress, string Status)
        {
            CustomerUpdate Reposi = new CustomerUpdate();
            AdminDashboardViewModel viewModel = new AdminDashboardViewModel();
            UpdateCustomer model = new UpdateCustomer();

            model = Reposi.UpdateCustomerList(CustomerID,CustomerName,Address,PhoneNumber,Password,EmailAddress,Status);
            viewModel.CustomerListUpdate = model;
            return viewModel;


        }
        public AdminDashboardViewModel GetVideoByID (string VideoID)
        {
            VideoGetByID Repos = new VideoGetByID();
            AdminDashboardViewModel viewModel = new AdminDashboardViewModel();
            List<VideoGetbyID> model = new List<VideoGetbyID>();

            model = Repos.GetVideobyID(VideoID);
            viewModel.VideoByID = model;

            return viewModel;

        }
        public AdminDashboardViewModel GetCustomerByID(string CustomerID)
        {
            CustomerGetByID Repos = new CustomerGetByID();
            AdminDashboardViewModel viewModel = new AdminDashboardViewModel();
            List<CustomerGetbyID> model = new List<CustomerGetbyID>();

            model = Repos.GetCustomerByID(CustomerID);
            viewModel.CustomerByID = model;

            return viewModel;

        }
    }
}
