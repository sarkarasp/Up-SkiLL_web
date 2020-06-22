using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Code_Box.Models;
using Code_Box.Domain.Repositories;
using Code_Box.Controllers;
using System.Web.Script.Serialization;
namespace Code_Box.Admin
{
    public class PostBlogController :  BaseController
    {
        // GET: PostBlog
        Repositories repository = new Repositories();

        public ActionResult PostToturials()
        {
            BlogViewModel list = new BlogViewModel();
           ViewBag.CourseList = new SelectList(repository.GetAllCoursesDetailsList(), "CoursesID", "CourseName");
            ViewBag.TopicList = new SelectList(repository.GetTopicListAll(), "id", "navName");
            return View(list);
        }
        [HttpPost]
        public ActionResult PostToturials(BlogViewModel model)
        {
            var result = repository.PostBlog(model.CourseId, model.TopicId, model.Blog_Heading, model.Author, model.Description, model.Categories, model.PageContent);
            Success(string.Format("<div class='page - header panel - default'><b>{0}</b></div> was successfully added to the database.", "Blog Data"), true);
            ViewBag.CourseList = new SelectList(repository.GetAllCoursesDetailsList(), "CoursesID", "CourseName");
            ViewBag.TopicList = new SelectList(repository.GetTopicListAll(), "id", "navName");
            return View();
            
        }
        [HttpPost]
        public ActionResult FillTopic(int courseId)
        {
            var topicList = repository.GetTopicListById(courseId).Select(d => new { d.id, d.navName});
            return Json(topicList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseList()
        {
            var result = repository.GetAllCoursesDetailsList().Select(c => new { c.CoursesID, c.CourseName});
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTopicList()
        {
            var TopicList = repository.GetTopicListAll().Select(t =>new { t.id, t.navName});
            return Json(TopicList, JsonRequestBehavior.AllowGet);
        }

    }
}