using DAC.StoredProcedure;
using MrEOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Core
{
    public class CoreGetCustomersAll
    {
        public AdminDashboardViewModel getAllcustomers()
        {
            CustomerGetAll dac = new CustomerGetAll();
            List<AllCustomers> allcustomer = new List<AllCustomers>();

            AdminDashboardViewModel viewModel = new AdminDashboardViewModel();

            allcustomer = dac.GetCustomerAll();
            viewModel.GetAllCustomers = allcustomer;
            return viewModel;
        }
    }
}
