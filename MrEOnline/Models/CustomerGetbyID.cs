using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrEOnline.Models
{
    public class CustomerGetbyID
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string StatusID { get; set; }
        public string StatusName { get; set; }
    }
}