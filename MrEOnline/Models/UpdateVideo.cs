using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrEOnline.Models
{
    public class UpdateVideo
    {

        public string VideoID { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string RentalPrice { get; set; }
        public string Status { get; set; }
        public string Result { get; set; }
    }
}