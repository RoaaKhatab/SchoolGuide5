using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolGuide5.Models;

namespace SchoolGuide4.Controllers
{
    public class ParentController : Controller
    {
        // GET: Parent
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        
    }
}