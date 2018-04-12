using Core;
using DAC;
using MrEOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mvc;


namespace MrEOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ListofVideos()
        {
            CoreVideoLists core = new CoreVideoLists();
            var list = core.VideoView();
            return Json(list,JsonRequestBehavior.AllowGet );
        }
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
            CoreAdministration core = new CoreAdministration();
            return View(core.GetStatusDropdown());
        }
        public ActionResult AdminInsert(string AdminName, string EmailAddress, string AdminPassword)
        {
            CoreAdminInsert core = new CoreAdminInsert();
            return Json(core.InsertAdmin(AdminName, EmailAddress, AdminPassword), JsonRequestBehavior.AllowGet);
        }
        public ActionResult VideoUpdate(string VideoID, string Title, string Description, string Genre, string RentalPrice, string Status)
        {
            CoreAdministration core = new CoreAdministration();
            return Json(core.UpdateVideos(VideoID, Title, Description, Genre, RentalPrice, Status), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UploadCsvFile(string filePath)
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fileName;

                        fileName = file.FileName;

                        fileName = Path.Combine(filePath, fileName);

                        List<VideoInfo> uploadModelList = new List<VideoInfo>();

                        string csvData = System.IO.File.ReadAllText(fileName);

                        foreach (string row in csvData.Split('\n'))
                        {
                            VideoInfo uploadModelRecord = new VideoInfo();
                            if (!string.IsNullOrEmpty(row))
                            {
                                int a = 0;
                                string VideoList = "";
                                string Title = "";
                                string Description = "";
                                string Genre = "";
                                string RentalPrice = "";

                                //Execute a loop the columns
                                foreach (string cellValue in row.Split(';'))
                                {
                                    string cell = cellValue.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                                    if (a == 0)
                                    {
                                        Title = cell;
                                    }
                                    else if (a == 1)
                                    {
                                        Description = cell;
                                    }
                                    else if (a == 2)
                                    {
                                        Genre = cell;
                                    }
                                    else if (a == 3)
                                    {
                                        RentalPrice = cell;
                                    }
                                    a++;
                                }
                                VideoList = Title + Description + Genre + RentalPrice;
                                uploadModelRecord.Title = Title;
                                uploadModelRecord.Description = Description;
                                uploadModelRecord.Genre = Genre;
                                uploadModelRecord.RentalPrice = RentalPrice;
                            }
                            uploadModelList.Add(uploadModelRecord);
                        }
                        Constants constants = new Constants();
                        using (SqlConnection con = new SqlConnection(constants.connectionString))
                        {
                            foreach (var item in uploadModelList)
                            {
                                CoreVideoListAdd insert = new CoreVideoListAdd();
                                insert.InsertVideo(item.Title, item.Description, item.Genre, item.RentalPrice);
                            }
                            con.Close();
                        }
                    }
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {

                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            return Json("No files selected.");
        }
        public ActionResult AddNewVideo(string Title, string Description, string Genre, string RentalPrice)
        {
            CoreVideoListAdd core = new CoreVideoListAdd();
            return Json(core.InsertVideo(Title,Description,Genre,RentalPrice), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetVideoID(string VideoID)
        {
            CoreAdministration core = new CoreAdministration();
            return Json(core.GetVideoByID(VideoID),JsonRequestBehavior.AllowGet);
        }
        public ActionResult AllCustomers()
        {
            CoreGetCustomersAll core = new CoreGetCustomersAll();
            return Json(core.getAllcustomers(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCustomerID(string CustomerID)
        {
            CoreAdministration core = new CoreAdministration();
            return Json(core.GetCustomerByID(CustomerID),JsonRequestBehavior.AllowGet);
        }

        public ActionResult CustomersUpdate(string CustomerID, string CustomerName, string Address, string PhoneNumber, string Password, string EmailAddress, string Status)
        {
            CoreAdministration core = new CoreAdministration();
            return Json(core.UpdateCustomers(CustomerID,CustomerName,Address,PhoneNumber,Password,EmailAddress,Status),JsonRequestBehavior.AllowGet);
        }
    }
}