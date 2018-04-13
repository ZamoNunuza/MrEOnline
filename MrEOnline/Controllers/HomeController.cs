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
        //Admin Dashboard
        public ActionResult AdminDashboard(string Username )
        {
            if (Username is null)
            {
                ViewBag.Message = "Please Login in!!";
                return View();
            }
            else {
                ViewBag.RemoveSelectedTitle = "User";
                ViewBag.RemoveSelectedactionName = Username;
                CoreAdministration core = new CoreAdministration();
                return View(core.GetStatusDropdown());
            }
            
        }
        // Video Administration and Admin Insert
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
        //Customer Administration
        public ActionResult CustomerAdministration(string userName)
        {
            if (userName is null)
            {
                ViewBag.Message = "Please Login in!!";
                return View();
            }
            else
            {
                ViewBag.RemoveSelectedTitle = "User";
                ViewBag.RemoveSelectedactionName = userName;
                CoreAdministration core = new CoreAdministration();
                return View(core.GetStatusDropdown());
            }
        }
            //get all customers
        public ActionResult AllCustomers()
        {
            CoreGetCustomersAll core = new CoreGetCustomersAll();
            return Json(core.getAllcustomers(), JsonRequestBehavior.AllowGet);
        }
            //customer by ID
        public ActionResult GetCustomerID(string CustomerID)
        {
            CoreAdministration core = new CoreAdministration();
            return Json(core.GetCustomerByID(CustomerID),JsonRequestBehavior.AllowGet);
        }
            //updating a customer record
        public ActionResult CustomersUpdate(string CustomerID, string CustomerName, string Address, string PhoneNumber, string Password, string EmailAddress, string Status)
        {
            CoreAdministration core = new CoreAdministration();
            return Json(core.UpdateCustomers(CustomerID,CustomerName,Address,PhoneNumber,Password,EmailAddress,Status),JsonRequestBehavior.AllowGet);
        }
        //Customer Dashboard
        public ActionResult CustomerDashboard(string username)
        {
            if (username is null)
            {
                ViewBag.Message = "Please Login in!!";
                return View();
            }
            else
            {
                ViewBag.ReturnVi = "Return Video";
                ViewBag.RemoveSelectelactionName = "CustomerDashboard";
                ViewBag.RemoveSelectedTitle = "User";
                ViewBag.RemoveSelectedactionName = username;
                return View();
            }
        }
        //Views all the videos availale
        public ActionResult ViewVideosCustomer()
        {
            CoreCustomer core = new CoreCustomer();
            return Json(core.VideoView(),JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        //Take all the Rental information to the database
        public ActionResult VideoRental(List<string> VideoID, string CustomerName, string CustomerPhone, List<string> Title)
        {
            CoreCustomer core = new CoreCustomer();
            string videoIDs = string.Join(",", VideoID );
            string title = string.Join(",", Title);

            return Json(core.InsertRental(videoIDs, CustomerName,CustomerPhone, title),JsonRequestBehavior.AllowGet);
        }
        //returning videos rented
        public ActionResult VideoReturn(string username)
        {
            if (username is null)
            {
                ViewBag.Message = "Please Login in!!";
                return View();
            }
            else
            {
                ViewBag.RemoveSelectedTitle = "User";
                ViewBag.RemoveSelectedactionName = username;
                return View();
            }
        }
        public ActionResult SearchByPhone(string PhoneNumber)
        {
            CoreCustomer core = new CoreCustomer();
            return Json(core.SearchReturn(PhoneNumber), JsonRequestBehavior.AllowGet);

        }
        public ActionResult UpdateReturn(string RentalID, string VideoID)
        {
            CoreCustomer core = new CoreCustomer();
            return Json(core.UpdateRentalReturn(RentalID, VideoID),JsonRequestBehavior.AllowGet);
        }
    }
}