using MrEOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AdminDashboardViewModel
    {
        public AdministrationInsert AdminInsert { get; set; }
        public List<AddVideo> VideoListInsert { get; set; }
        public List<AllVideos> VideoView { get; set; } 
        public List<AllCustomers> GetAllCustomers { get; set; }
        public List<Status> DropdownStatus { get; set; }
        public UpdateVideo VideoListUpdate { get; set; }
        public UpdateCustomer CustomerListUpdate { get; set; }
        public List<VideoGetbyID> VideoByID { get; set; }
        public List<CustomerGetbyID> CustomerByID { get; set;}
    }
}
