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
    public class CoreCustomerGetByUsername
    {
        public LoginViewModel GetCustomerUserName(string UserName)
        {
            CustomerGetByUsername Repos = new CustomerGetByUsername();
            LoginViewModel viewModel = new LoginViewModel();
            List<CustomerGetbyUsername> model = new List<CustomerGetbyUsername>();

            model = Repos.GetCustomerByUserName(UserName);
            viewModel.GetCustomerByUsername = model;

            return viewModel;

        }

    }
}
