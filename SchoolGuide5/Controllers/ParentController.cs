using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolGuide5.Models;
using Microsoft.AspNet.Identity;
using SchoolGuide5.ViewModels;
using System.Net;

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

        
       
            [Authorize(Roles ="Parents")]

        public ActionResult Whishlist()
        {
            var currentuser = User.Identity.GetUserId();
            var whishlist= db.Whishlist.Where(x => x.User_id == currentuser).ToList();


            return View(whishlist);
        }

        [Authorize(Roles = "Parents")]

        public ActionResult AddToWhishlist(Whishlist whishlist,int? id)
        {
            whishlist.User_id = User.Identity.GetUserId();
            whishlist.SC_ID = id;
            db.Whishlist.Add(whishlist);
            db.SaveChanges();
            return RedirectToAction("Whishlist");
                  
        }




        [Authorize(Roles = "Parents")]

        public ActionResult RemoveFromWhishlist(int?id)
        {
            var school = db.Whishlist.Find(id);
            db.Whishlist.Remove(school);
            db.SaveChanges();
            return RedirectToAction("Whishlist");

            


        }











        //POST: Schools/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Schools schools = db.Schools.Find(id);
        //    db.Schools.Remove(schools);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


    }
}