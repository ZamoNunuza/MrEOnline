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
    public class CoreRegistrationInsert
    {
        public RegistrationViewModel InsertCustomer(string customerName, string address, string phoneNumber, string Password, string emailAddress)
        {
            Registration Reposi = new Registration();
            RegistrationViewModel viewModel = new RegistrationViewModel();
            RegistrationInsert model = new RegistrationInsert();

            model = Reposi.registrationInesrt(customerName, address, phoneNumber, Password, emailAddress);
            viewModel.registrationInsert = model;
            return viewModel;


        }
    }
}
