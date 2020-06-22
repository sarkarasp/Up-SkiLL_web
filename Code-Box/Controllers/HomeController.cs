using Code_Box.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Code_Box.Models;
using System.IO;
using Code_Box.Domain.Repositories;
using Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;
//using System.Text.RegularExpressions;

namespace Code_Box.Controllers
{
    public class HomeController : Controller
    {
        Repositories Context = new Repositories();
        protected Application objWord = new Application();
        //This creates new object of Word.ApplicationClass  
        protected string strPathToUpload;
        //Path to upload files "Uploaded"  
        protected string strPathToConvert;
        //Path to convert uploaded files and save  
        object fltDocFormat = 10;
        //For filtered HTML Output  
        protected object missing = System.Reflection.Missing.Value;
        //Is just to skeep the parameters which are passed as boject reference, these are seems to be optional parameters  
        protected object readOnly = false;
        protected object isVisible = false;
        public ActionResult Index()
        {
            return View();
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

        [HttpGet]
        public ActionResult UploadDocument()
        {
            List<SelectListItem> courseNames = new List<SelectListItem>();
            TopicDetailModel topicDetailViewModel = new TopicDetailModel();
            List<Courses_tb> Courses = Context.GetAllCoursesDetailsList().ToList<Courses_tb>();
            var Topics = Context.GetTopicListAll();

            Courses.ForEach(x =>
            {
                courseNames.Add(new SelectListItem { Text = x.CourseName, Value = x.CoursesID.ToString() });
            });

            topicDetailViewModel.CourseNames = courseNames;

            ViewBag.Topics = Context.GetTopicListById(1);

            return View(topicDetailViewModel);
        }

        [HttpPost]
        public ActionResult GetTopics(string courseId)
        {
            int courseID;
            List<SelectListItem> TopicNames = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(courseId))
            {
                courseID = Convert.ToInt32(courseId);
                List<Vertical_Nav_tb> Topics = Context.GetTopicListById(courseID).ToList<Vertical_Nav_tb>();
                Topics.ForEach(x =>
                {
                    TopicNames.Add(new SelectListItem { Text = x.navName, Value = x.id.ToString() });
                });
            }
            return Json(TopicNames, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadDocument(TopicDetailModel _model, FormCollection formcollection)
        {
            List<SelectListItem> courseNames = new List<SelectListItem>();
            TopicDetailModel topicDetailViewModel = new TopicDetailModel();
            List<Courses_tb> Courses = Context.GetAllCoursesDetailsList().ToList<Courses_tb>();
            var Topics = Context.GetTopicListAll();

            Courses.ForEach(x =>
            {
                courseNames.Add(new SelectListItem { Text = x.CourseName, Value = x.CoursesID.ToString() });
            });

            topicDetailViewModel.CourseNames = courseNames;

            ViewBag.Topics = Context.GetTopicListById(1);

            _model.CreatedDate = DateTime.Now;
            _model.UpdateDate = DateTime.Now;
            _model.isActive = true;
            _model.CourseId = Convert.ToInt32(formcollection["CourseId"]);
            _model.TopicId = Convert.ToInt32(formcollection["TopicId"]); 
            var TopicPath = saveFileData(_model.TopicPath);
             Context.InsertTopicDetails(_model.TopicId, _model.TopicName, _model.TechnologyType, 
                                         _model.PostedBy, _model.CreatedDate, _model.UpdateDate, _model.isActive, _model.CourseId, TopicPath);
           
            return View(topicDetailViewModel);
        }

        private string SaveToPhysicalLocation(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var strFileName = Path.GetFileName(file.FileName);
                string[] strSep = file.FileName.Split('.');
                int arrLength = strSep.Length - 1;
                string strExt = strSep[arrLength].ToString().ToUpper();
                //Save the uploaded file to the folder  
               var strPathToUpload = Server.MapPath("~/App_Data");
                //Map-path to the folder where html to be saved  
               var strPathToConvert = Server.MapPath("WordToHtml");
                object FileName = strPathToUpload + "\\" + file.FileName;
                object FileToSave = strPathToUpload + "\\" + file.FileName + ".htm";
                if (strExt.ToUpper().Equals("DOCX"))
                {
                    file.SaveAs(strPathToUpload + "\\" + file.FileName);
                    //lblMessage.Text = "File uploaded successfully";
                    //open the file internally in word. In the method all the parameters should be passed by object reference  
                    objWord.Documents.Open(ref FileName, ref readOnly, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing,
                    ref missing, ref missing);
                    //Do the background activity  
                    objWord.Visible = false;
                    Microsoft.Office.Interop.Word.Document oDoc = objWord.ActiveDocument;
                    oDoc.SaveAs(ref FileToSave, ref fltDocFormat, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing);
                    // lblMessage.Text = fUpload.FileName + " converted to HTML successfully";
                   /// oDoc.Close();
                   // objWord.Quit();
                }
                else
                {
                   // lblMessage.Text = "Invalid file selected!";
                }

                var path = Path.Combine(Server.MapPath("~/App_Data"), strFileName);
                file.SaveAs(path);
                return path;
            }
            return string.Empty;
        }

        private string saveFileData(HttpPostedFileBase postedFile)
        {
            object documentFormat = 8;
            string randomName = DateTime.Now.Ticks.ToString();
            object htmlFilePath = Server.MapPath("~/Temp/") + randomName + ".htm";
            string directoryPath = Server.MapPath("~/Temp/") + randomName + "_files";
            object fileSavePath = Server.MapPath("~/Temp/") + Path.GetFileName(postedFile.FileName);

            //If Directory not present, create it.
            if (!Directory.Exists(Server.MapPath("~/Temp/")))
            {
                Directory.CreateDirectory(Server.MapPath("~/Temp/"));
            }

            //Upload the word document and save to Temp folder.
            postedFile.SaveAs(fileSavePath.ToString());

            //Open the word document in background.
            _Application applicationclass = new Application();
            applicationclass.Documents.Open(ref fileSavePath);
            applicationclass.Visible = false;
            Document document = applicationclass.ActiveDocument;

            //Save the word document as HTML file.
            document.SaveAs(ref htmlFilePath, ref documentFormat);

            //Close the word document.
            document.Close();

            //Read the saved Html File.
            string wordHTML = System.IO.File.ReadAllText(htmlFilePath.ToString());

            //Loop and replace the Image Path.
            foreach (Match match in Regex.Matches(wordHTML, @"src=(?:(['""])(?<src>(?:(?!\1).)*)\1|(?<src>[^\s>]+))", RegexOptions.IgnoreCase))
            {
                var matchpath = "/Temp/" + match.Groups[2].Value; //"<img.+?src=[\"'](.+?)[\"'].*?>"
                wordHTML = Regex.Replace(wordHTML,  match.Groups[2].Value, matchpath);
            }

            //Delete the Uploaded Word File.
            System.IO.File.Delete(fileSavePath.ToString());

            // document.SaveAs(ref htmlFilePath, ref documentFormat);

            System.IO.File.WriteAllText(htmlFilePath.ToString(), wordHTML);

            // ViewBag.WordHtml = wordHTML;
            return htmlFilePath.ToString();

        }

    }
}