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
    public class CoreAdminInsert
    {
        public AdminDashboardViewModel InsertAdmin(string AdminName, string EmailAddress, string AdminPassword)
        {
            AdminInsert Reposi = new AdminInsert();
            AdminDashboardViewModel viewModel = new AdminDashboardViewModel();
            AdministrationInsert model = new AdministrationInsert();

            model = Reposi.adminInesrt(AdminName,EmailAddress,AdminPassword);
            viewModel.AdminInsert = model;
            return viewModel;


        }
    }
}
