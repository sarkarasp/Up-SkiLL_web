using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Code_Box.Domain.Repositories;

namespace Code_Box.Controllers
{
    public class TutorialsController : Controller
    {
     
        Repositories repo = new Repositories();
        //public TutorialsController(IRepo repo)
        //{
        //    _repository = repo;
        //}

        // GET: Tutorials
        public ActionResult ToturialsIndex()
        {
             ViewBag.Coures = repo.GetAllCoursesDetailsList();
            //ViewBag.Topics = result.Select(c => c.Topic);

            return View();
        }
    }
}