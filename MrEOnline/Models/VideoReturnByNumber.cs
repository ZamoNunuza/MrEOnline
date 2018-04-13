using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrEOnline.Models
{
    public class VideoReturnByNumber
    {
       public string RentalID{get; set;}
        public string CustomerID { get; set; }
        public string VideoID { get; set; }
        public string Title { get; set; }
        public string CustomerPhone { get; set; }
        public string RentalDate { get; set; }
    }
}