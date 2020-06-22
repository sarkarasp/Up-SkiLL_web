using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code_Box.Controllers
{
    public class MVCController : Controller
    {
        // GET: MVC
        public ActionResult MVCTutorials()
        {
            return View();
        }
    }
}