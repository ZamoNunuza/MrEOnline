using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrEOnline.Models
{
    public class AddVideo
    {
        public string result { get; set; }
        public List<VideoInfo> videoInformation { get; set; }
    }
    public class VideoInfo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string RentalPrice { get; set; }
    }
}