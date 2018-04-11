using Core;
using DAC;
using MrEOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

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
        public ActionResult AdminInsert(string AdminName, string EmailAddress, string AdminPassword)
        {
            CoreAdminInsert core = new CoreAdminInsert();
            return Json(core.InsertAdmin(AdminName, EmailAddress, AdminPassword), JsonRequestBehavior.AllowGet);
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
                    return Json(null);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            //var attachedFile = System.Web.HttpContext.Current.Request.Files["uploadFile"];
            //if (attachedFile == null || attachedFile.ContentLength <= 0) return Json(null);
            //var csvReader = new StreamReader(attachedFile.InputStream);
            ////List<VideoInfo> uploadModelList = new List<VideoInfo>();
            //string inputDataRead;
            //var values = new List<string>();
            //while ((inputDataRead = csvReader.ReadLine()) != null)
            //{
            //    values.Add(inputDataRead.Trim().Replace(" ", "").Replace(",", " "));
            //}
            //values.Remove(values[0]);
            //values.Remove(values[values.Count - 1]);

            //Constants constants = new Constants();
            //using (SqlConnection con = new SqlConnection(constants.connectionString))
            //{
            //    foreach (var value in values)
            //    {
            //        //VideoInfo uploadModelRecord = new VideoInfo();
            //        var eachValue = value.Split(' ');
            //        uploadModelRecord.Title = eachValue[0] != "" ? eachValue[0] : string.Empty;
            //        uploadModelRecord.Description = eachValue[1] != "" ? eachValue[1] : string.Empty;
            //        uploadModelRecord.Genre = eachValue[2] != "" ? eachValue[2] : string.Empty;
            //        uploadModelRecord.RentalPrice = eachValue[3] != "" ? eachValue[3] : string.Empty;

            //        uploadModelList.Add(uploadModelRecord);// newModel needs to be an object of type ContextTables.
            //        con.Close();
            //    }
            //    //con.SaveChanges()
            //}
            return Json(null);
        }
    }
}