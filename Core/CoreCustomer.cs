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
        public CustomerDashbordViewModel InsertRental(string VideoID, string CustomerName, string CustomerPhone, string Title)
        {
            VideoRentalAdd Reposi = new VideoRentalAdd();
            CustomerDashbordViewModel viewModel = new CustomerDashbordViewModel();
            VideoRental model = new VideoRental();

            model = Reposi.AddRentalVideo(VideoID, CustomerName, CustomerPhone, Title);
            viewModel.videoRentalInsert = model;
            return viewModel;


        }
        public CustomerDashbordViewModel UpdateRentalReturn(string RentalID, string VideoID)
        {
            ReturnVideoUpdate repos = new ReturnVideoUpdate();
            CustomerDashbordViewModel viewModel = new CustomerDashbordViewModel();
            VideoUpdateReturn model = new VideoUpdateReturn();

            model = repos.GetVideosReturn(RentalID, VideoID);
            viewModel.videoRentalUpdate = model;
            return viewModel;

        }
        public CustomerDashbordViewModel SearchReturn(string PhoneNumber)
        {
            SearchReturnByNumber repos = new SearchReturnByNumber();
            CustomerDashbordViewModel viewModel = new CustomerDashbordViewModel();
            List<VideoReturnByNumber> model = new List<VideoReturnByNumber>();

            model = repos.GetVideoBuySearch(PhoneNumber);
            viewModel.VideoByNumber = model;
            return viewModel;


        }
    }
}
