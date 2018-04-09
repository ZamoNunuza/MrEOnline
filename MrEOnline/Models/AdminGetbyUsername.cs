using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrEOnline.Models
{
    public class AdminGetbyUsername
    {
        public string AdminID { get; set; }
        public string AdminName { get; set; }
        public string EmailAddress { get; set; }
        public string AdminPassword { get; set; }
    }
}