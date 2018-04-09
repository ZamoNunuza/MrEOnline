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
    public class CoreAdminGetByUsername
    {
        public LoginViewModel GetAdminUserName(string UserName)
        {
            AdminGetByUsername Repos = new AdminGetByUsername();
            LoginViewModel viewModel = new LoginViewModel();
            List<AdminGetbyUsername> model = new List<AdminGetbyUsername>();

            model = Repos.GetAdminByUserName(UserName);
            viewModel.GetAdminByUserName = model;

            return viewModel;

        }
    }
}
