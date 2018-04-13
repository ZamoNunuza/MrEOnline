using MrEOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CustomerDashbordViewModel
    {
        public List<VideosGetbyStatus> AllVideosView { get; set; }
        public VideoRental videoRentalInsert { get; set; }
        public List<VideoReturnByNumber> VideoByNumber { get; set; }
        public VideoUpdateReturn videoRentalUpdate { get; set; }
    }
}
