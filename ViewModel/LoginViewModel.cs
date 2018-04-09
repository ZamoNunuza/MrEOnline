using MrEOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LoginViewModel
    {
        public List<CustomerGetbyUsername> GetCustomerByUsername { get; set; }
        public List<AdminGetbyUsername> GetAdminByUserName { get; set; }
    }
}
