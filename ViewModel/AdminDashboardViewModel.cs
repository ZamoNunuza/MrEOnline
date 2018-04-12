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
        public List<UpdateVideo> VideoListUpdate { get; set; }
    }
}
