using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrEOnline.Models
{
    public class VideosGetbyStatus
    {
        public string VideoID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string RentalPrice { get; set; }
        public string StatusName { get; set; }

    }
}