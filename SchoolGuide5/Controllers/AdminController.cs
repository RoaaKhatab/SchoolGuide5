﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolGuide5.Models;


namespace SchoolGuide4.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admins")]
        public ActionResult ViewUsers()

        {

            return View(db.Users.ToList());

        }

        [Authorize(Roles = "Admins")]
        public ActionResult Delete(ApplicationUser user)
        {
            var Customer = db.Users.Find(user.Id);
            db.Users.Remove(Customer);
            db.SaveChanges();

            return RedirectToAction("ViewUsers");

        }

        
        [Authorize(Roles ="Admins")]
        public ActionResult DeleteSchool(int id)
        {
            var School = db.Schools.Where(u => u.Sc_id.Equals(id)).SingleOrDefault();
            db.Schools.Remove(School);
            db.SaveChanges();
            return RedirectToAction("Index","Schools");
        }

        [Authorize(Roles = "Admins")]
        public ActionResult AddSchool()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSchool(Schools School, HttpPostedFileBase Upload,HttpPostedFileBase UploadPdf)
        {

            //save pdf
            string PdfPath = Path.Combine(Server.MapPath("~/UploadsPdf"), UploadPdf.FileName);
            UploadPdf.SaveAs(PdfPath);
            School.Sc_App = UploadPdf.FileName;

            //save image
            string path = Path.Combine(Server.MapPath("~/Uploads"), Upload.FileName);
            Upload.SaveAs(path);
            db.Schools.Add(School);
            School.Sc_Image = Upload.FileName;
            db.SaveChanges();
            return RedirectToAction("Index", "Schools");
        }

        [Authorize(Roles = "Admins")]
        public ActionResult EditSchool(int id)
        {
            return View(db.Schools.Where(c => c.Sc_id.Equals(id)).SingleOrDefault());
        }
        [HttpPost]
        public ActionResult EditSchool(Schools school)
        {
            db.Entry<Schools>(school).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index","Schools");
        }
        

        /*              FAQ             */

        public ActionResult ViewFAQ()

        {

            return View(db.FAQs.ToList());

        }

        [Authorize(Roles = "Admins")]
        public ActionResult DeleteFAQ(int id)
        {
            var faqq = db.FAQs.Where(u => u.FAQ_ID.Equals(id)).SingleOrDefault();
            db.FAQs.Remove(faqq);
            db.SaveChanges();
            return RedirectToAction("ViewFAQ");
        }



        [Authorize(Roles = "Admins")]
        public ActionResult AddFAQ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFAQ(FAQ faq)
        {
            db.FAQs.Add(faq);
            db.SaveChanges();

            return RedirectToAction("ViewFAQ");
        }



        [Authorize(Roles = "Admins")]
        public ActionResult EditFAQ(int id)
        {
            return View(db.FAQs.Where(c => c.FAQ_ID.Equals(id)).SingleOrDefault());
        }
        [HttpPost]
        public ActionResult EditFAQ(FAQ faq)
        {
            db.Entry<FAQ>(faq).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ViewFAQ");
        }

    }
}