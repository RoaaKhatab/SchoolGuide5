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

        public ActionResult Filteration(string SchoolCategory, string SchoolFeesFrom, string SchoolFeesTo, string SchoolLocation)
        {

            var result = from s in db.Schools
                         select s;
            // var result = _context.car.Include(b => b.Type);
            if (!string.IsNullOrEmpty(SchoolCategory))
            {
                result = db.Schools.Where(x => x.Sc_Category.Contains(SchoolCategory));

            }
            if (!string.IsNullOrEmpty(SchoolFeesFrom))
            {
                result = db.Schools.Where(x => x.Sc_Fees_From == SchoolFeesFrom);

            }

            if (!string.IsNullOrEmpty(SchoolFeesTo))
            {
                result = db.Schools.Where(x => x.Sc_Fees_To == SchoolFeesTo);

            }
            if (!string.IsNullOrEmpty(SchoolLocation))
            {
                result = db.Schools.Where(x => x.Sc_Location == SchoolLocation);

            }


            return View(result);

        }
    }
}