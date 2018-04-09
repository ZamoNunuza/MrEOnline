﻿using Core;
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
            return View();
        }

        public ActionResult RegistrationInsert(string customerName, string address, string phoneNumber, string password, string emailAddress)
        {
            CoreRegistrationInsert core = new CoreRegistrationInsert();
            return Json(core.InsertCustomer(customerName,address,phoneNumber,password,emailAddress), JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}