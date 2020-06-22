using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Code_Box.Domain.Repositories;
using Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;
using System.IO;
using Code_Box.Models;

namespace Code_Box.Controllers
{
    public class CSharpController : Controller
    {
        // GET: CSharp
        Repositories repo = new Repositories();
        public ActionResult CSharpTutorial(int courseId, int topicId)
        {
           PageDetailsModel pageViewModel = new PageDetailsModel();
            string returnUrl = "http://localhost:49590/CSharp/CSharpTutorial?courseId=" + courseId + "&&topicId=" + topicId;

            var Details = repo.GetDocumentPath(courseId, topicId);

            //object htmlFilePath = @"E:\Code-Box\Code-Box\App_Data\C# Tutorials.docx.htm";
            object htmlFilePath = Details.TopicPath;

            var result = repo.GetAllCourseDetailsByID(courseId);

            foreach (var item in result)
            {
                VerticalViewModel ViewModelResult = new VerticalViewModel();
                ViewModelResult.DocPath = item.TopicDetails_tb.Select(x => x.TopicPath).FirstOrDefault();
                ViewModelResult.TopicId = Convert.ToInt32(item.TopicDetails_tb.Select(x => x.TopicId).FirstOrDefault());
                ViewModelResult.TopicName = item.navName;
                ViewModelResult.CourseName = item.Courses_tb.CourseName;
                ViewModelResult.CourseId = Convert.ToInt32(item.CourseID);
                pageViewModel.verticalViewModels.Add(ViewModelResult);
            }
                ViewBag.Coures = repo.GetAllCoursesDetailsList();
            
                ViewBag.Topics = repo.GetTopicListById(courseId);

                string wordHTML = System.IO.File.ReadAllText(htmlFilePath.ToString());
                ViewBag.ContainsHtml = wordHTML.ToString();
                pageViewModel.CourseIds = courseId;
                pageViewModel.topicIds = topicId;
          
            return View(pageViewModel);           
        }

        [HttpGet]
        public JsonResult TopicDetails(int courseId, int topicId)
        {
            PageDetailsModel pageViewModel = new PageDetailsModel();
            var Details = repo.GetDocumentPath(courseId, topicId);
            object htmlFilePath = Details.TopicPath;
            string returnUrl = "http://localhost:49590/CSharp/CSharpTutorial?courseId="+ courseId +"&&topicId=" + topicId;

            var result = repo.GetAllCourseDetailsByID(courseId);
             
            foreach (var item in result)
            {
                VerticalViewModel ViewModelResult = new VerticalViewModel();
                ViewModelResult.DocPath = item.TopicDetails_tb.Select(x => x.TopicPath).FirstOrDefault();
                ViewModelResult.TopicId = Convert.ToInt32(item.TopicDetails_tb.Select(x => x.TopicId).FirstOrDefault());
                ViewModelResult.TopicName = item.navName;
                ViewModelResult.CourseId = Convert.ToInt32(item.CourseID);
                pageViewModel.verticalViewModels.Add(ViewModelResult);
            }
            ViewBag.Coures = repo.GetAllCoursesDetailsList();

            //var model = repo.GetAllCourseDetailsByID(courseId);   

            ViewBag.Topics = repo.GetTopicListById(courseId);

            string wordHTML = System.IO.File.ReadAllText(htmlFilePath.ToString());
            ViewBag.ContainsHtml = wordHTML.ToString();
            pageViewModel.CourseIds = courseId;
            pageViewModel.topicIds = topicId;

            // return Redirect(returnUrl);
            return Json(returnUrl, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult NextDetails(int courseId, int topicId)
        {
            PageDetailsModel pageViewModel = new PageDetailsModel();
            topicId = topicId + 1;
            var Details = repo.GetDocumentPath(courseId, topicId);
            object htmlFilePath = Details.TopicPath;
            string returnUrl = "http://localhost:49590/CSharp/CSharpTutorial?courseId=" + courseId + "&&topicId=" + topicId;

            var result = repo.GetAllCourseDetailsByID(courseId);

            foreach (var item in result)
            {
                VerticalViewModel ViewModelResult = new VerticalViewModel();
                ViewModelResult.DocPath = item.TopicDetails_tb.Select(x => x.TopicPath).FirstOrDefault();
                ViewModelResult.TopicId = Convert.ToInt32(item.TopicDetails_tb.Select(x => x.TopicId).FirstOrDefault());
                ViewModelResult.TopicName = item.navName;
                ViewModelResult.CourseId = Convert.ToInt32(item.CourseID);
                pageViewModel.verticalViewModels.Add(ViewModelResult);
            }
            ViewBag.Coures = repo.GetAllCoursesDetailsList();

            //var model = repo.GetAllCourseDetailsByID(courseId);   

            ViewBag.Topics = repo.GetTopicListById(courseId);

            string wordHTML = System.IO.File.ReadAllText(htmlFilePath.ToString());
            ViewBag.ContainsHtml = wordHTML.ToString();
            pageViewModel.CourseIds = courseId;
            pageViewModel.topicIds = topicId;

            // return Redirect(returnUrl);
            return Json(returnUrl, JsonRequestBehavior.AllowGet);
        }
    }
}