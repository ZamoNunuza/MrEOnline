using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MrEOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.RemoveSelectedTitle = "User";
            ViewBag.RemoveSelectedactionName = "User";
            return View();
        }
        //Resgistration Insert for the Customer
        public ActionResult RegistrationInsert(string customerName, string address, string phoneNumber, string password, string emailAddress)
        {
            CoreRegistrationInsert core = new CoreRegistrationInsert();
            return Json(core.InsertCustomer(customerName, address, phoneNumber, password, emailAddress), JsonRequestBehavior.AllowGet);
        }
        //Getting infomation and CustomerID once that user logs in
        public ActionResult CustomerByUserName(string Username)
        {
           
            CoreCustomerGetByUsername core = new CoreCustomerGetByUsername();
            return Json(core.GetCustomerUserName(Username), JsonRequestBehavior.AllowGet);
        }
        //getting information of Mr. E Online's administration
        public ActionResult AdminByUserName(string userName)
        {
            CoreAdminGetByUsername core = new CoreAdminGetByUsername();
            return Json(core.GetAdminUserName(userName), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AdminDashboard(string Username)
        {
            ViewBag.RemoveSelectedTitle = "User";
            ViewBag.RemoveSelectedactionName = Username;
            return View();
        }
    }
}