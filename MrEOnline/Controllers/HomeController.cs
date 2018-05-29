using Core;
using DAC;
using MrEOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Xml;
using System.Data;
using System.Linq;

namespace MrEOnline.Controllers
{
    //[Authorize]
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
            //if (Username is null)
            //{
            //    ViewBag.Message = "Please Login in!!";
            //    return View();
            //}
            //else {
            //    ViewBag.RemoveSelectedTitle = "User";
            //    ViewBag.RemoveSelectedactionName = Username;
                CoreAdministration core = new CoreAdministration();
                return View(core.GetStatusDropdown());
            //}
            
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
            // Checking no of files injected in Request object
            if (Request.Files.Count > 0)
            {
                try
                {
                    string VideoList = "";
                    string Title = "";
                    string Description = "";
                    string Genre = "";
                    string RentalPrice = "";
                    //string Date;
                    DateTime dateTime = DateTime.UtcNow.Date;

                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {

                        HttpPostedFileBase file = files[i];
                        string fName;
                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fName = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fName = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.
                        XmlDocument configxml = new XmlDocument();
                        configxml.Load(AppDomain.CurrentDomain.BaseDirectory + "/Config.xml");

                        fName = configxml.GetElementsByTagName("UploadLocation").Item(0).InnerXml + fName;
                        fName = fName.Replace(@"\\", @"\");

                        file.SaveAs(fName);

                        DataTable dt = new DataTable();
                        dt.Columns.AddRange(new DataColumn[8] { new DataColumn("Title", typeof(string)),
                            new DataColumn("Description",typeof(string)),
                            new DataColumn("Genre",typeof(string)),
                            new DataColumn("RentalPrice",typeof(string)),
                            new DataColumn("Status",typeof(string)),
                            new DataColumn("UserAdded",typeof(string)),
                            new DataColumn("DateAdded",typeof(string)),
                            new DataColumn("RentalStatus",typeof(string))});

                        string csvData = System.IO.File.ReadAllText(fName);

                        List<AddVideo> lists = new List<AddVideo>();

                        AddVideo videoList = new AddVideo();

                        //Excute a loop over the rows
                        int RowCount = 0;
                        foreach (string row in csvData.Split('\n').Skip(1))
                        {
                            if (!string.IsNullOrEmpty(row))
                            {
                                dt.Rows.Add();
                                int a = 0;

                                //Execute a loop the columns
                                foreach (string cellValue in row.Split(';'))
                                {
                                    string cell = cellValue.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                                    if (RowCount == 0)
                                    {
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
                                    }
                                    dt.Rows[dt.Rows.Count - 1][a] = cell;
                                    a++;
                                }
                                RowCount++;
                                videoList.Title = Title;
                                videoList.Description = Description;
                                videoList.Genre = Genre;
                                videoList.RentalPrice = RentalPrice;
                            }
                            lists.Add(videoList);
                        }
                        


                        Constants constants = new Constants();
                        using (SqlConnection con = new SqlConnection(constants.connectionString))
                        {
                            foreach (var item in lists)
                            {
                                CoreVideoListAdd add = new CoreVideoListAdd();
                                add.InsertVideo(item.Title, item.Description, item.Genre, item.RentalPrice);
                            }
                            con.Close();
                            //using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                            //{
                            //    // Set the datatbase table name
                            //    //sqlBulkCopy.DestinationTableName = "[dbo].[VideoAdministration]";

                            //    //sqlBulkCopy.ColumnMappings.Add("Title","Title");
                            //    //sqlBulkCopy.ColumnMappings.Add("Description", "Description");
                            //    //sqlBulkCopy.ColumnMappings.Add("Genre", "Genre");
                            //    //sqlBulkCopy.ColumnMappings.Add("RentalPrice", "RentalPrice");
                            //    ////sqlBulkCopy.ColumnMappings.Add("Status", "1");
                            //    ////sqlBulkCopy.ColumnMappings.Add("UserAdded", "null");
                            //    ////sqlBulkCopy.ColumnMappings.Add("DateAdded", dateTime.ToString());
                            //    ////sqlBulkCopy.ColumnMappings.Add("RentalStatus", "Available");

                            //    //con.Open();
                            //    //sqlBulkCopy.WriteToServer(dt);
                            //    con.Close();
                            //}
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
            return Json(core.SearchByPhone(PhoneNumber), JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateReturn(string RentalID, string VideoID)
        {
            CoreCustomer core = new CoreCustomer();
            return Json(core.UpdateRentalReturn(RentalID, VideoID), JsonRequestBehavior.AllowGet);
        }
        //public ActionResult UpdateReturn(string RentalID, string VideoID)
        //{
        //    CoreCustomer core = new CoreCustomer();
        //    return Json(core.UpdateRentalReturn(RentalID, VideoID),JsonRequestBehavior.AllowGet);
        //}
    }
}