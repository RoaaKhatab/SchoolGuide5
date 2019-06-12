using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SchoolGuide5.Models;
using SchoolGuide5.ViewModels;
using System.Web.UI.WebControls;
using PagedList;
using System.IO;

namespace SchoolGuide5.Controllers
{
    public class SchoolsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Schools
        // search by Name or Category or Address
        public ActionResult Index()
        {
            return View(db.Schools.ToList());

        }
        // Filteration
        public ActionResult Filter(string Sc_Name, string Sc_Category
            , string Sc_Location, int? Sc_Fees_From, int? Sc_Fees_To)
        {
            var schools = from c in db.Schools
                          select c;
            if (!string.IsNullOrEmpty(Sc_Name))
            {
                schools = schools.Where(c => c.Sc_Name.Contains(Sc_Name));
            }
            if (!string.IsNullOrEmpty(Sc_Category))
            {
                schools = schools.Where(c => c.Sc_Category.Contains(Sc_Category));
            }
            if (!string.IsNullOrEmpty(Sc_Location))
            {
                schools = schools.Where(c => c.Sc_Location.Contains(Sc_Location));
            }

            if (Sc_Fees_From != null)
            {

                schools = schools.Where(c => c.Sc_Fees_From <= Sc_Fees_From);

            }
            if (Sc_Fees_To != null)
            {

                schools = schools.Where(c => c.Sc_Fees_To >= Sc_Fees_To);

            }

            return View(schools);
        }
        //paging
        public ActionResult paging(int? page)
        {
            var schools = from c in db.Schools
                          orderby c.Sc_id
                          select c;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(schools.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult searchpaging(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var schools = from c in db.Schools
                          select c;

            if (!string.IsNullOrEmpty(searchString))
            {

                schools = schools.Where(c => c.Sc_Name.Contains(searchString)
                || c.Sc_Location.Contains(searchString)
                || c.Sc_Category.Contains(searchString));
            }
            schools = schools.OrderBy(c => c.Sc_id); // default sorting
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(schools.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult SchoolApplication(int? id)
        {
            Schools schools = db.Schools.Find(id);
            if (Path.GetExtension(schools.Sc_App) == ".pdf")
            {
                string fullpath = Path.Combine(Server.MapPath("~/UploadsPdf"), schools.Sc_App);
                return File(fullpath, "UploadsPdf/pdf");
            }
            else
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
        }



        // GET: Schools/Details/5
        public ActionResult Details(int? id)
        {
            SchoolComments model = new SchoolComments();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Schools schools = db.Schools.Find(id);
            model.School = schools;
            model.Comment = db.Comments.Where(x => x.School_id == id).ToList();

            if (schools == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }



        public ActionResult AddComment()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddComment(Comment comment, int? id)
        {
            comment.School_id = id;
            comment.UserId = User.Identity.GetUserId();
            comment.Username = User.Identity.GetUserName();
            comment.C_Date = DateTime.Now;
            
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Details",new { id = comment.School_id });
        }




        //[HttpPost]

        //public JsonResult AddComment(CommentViewModel model)
        //{
        //    JsonResult result = new JsonResult();
        //    try
        //    {
        //        var comments = new Comment();
        //        comments.C_Details = model.Comment;
        //        comments.Username = User.Identity.GetUserName();
        //        comments.School_id = model.SchoolId;
        //        comments.UserId = User.Identity.GetUserId();
        //        comments.C_Date = DateTime.Now;

        //        result.Data = new { Success = SaveComment(comments) };


        //    }
        //    catch (Exception ex)
        //    {
        //        result.Data = new { Success = false, Message = ex.Message };
        //    }

        //    return result;
        //}

        //public bool SaveComment(Comment comment)
        //{
        //    db.Comments.Add(comment);
        //    return db.SaveChanges() > 0;
        //}

        //public List<Comment> GetComments(int? schoolId)
        //{
        //    return db.Comments.Where(x => x.School_id == schoolId).ToList();
        //}





        //}
        //public bool leaveComment (Comment comment)
        //{

        //    return db.SaveChanges() > 0;
        //}


        //public ActionResult comment()
        //{
        //    //ViewBag.Id = new SelectList(db.project, "Id", "pName");
        //    ViewBag.id = db.Comments.Where(x => x.School_id > 0).ToList();
        //    Comment com = new Comment();
        //    return PartialView("_comment", com);
        //}
        //public ActionResult AddComment(Comment com, int? SchoolId)
        //{

        //    //com.School_id = SchoolId;
        //    com.UserId = User.Identity.GetUserId();
        //    com.C_Date = DateTime.Now;

        //    db.Comments.Add(com);
        //    db.SaveChanges();
        //    return RedirectToAction("Details",new { id =SchoolId});
        //}
        //public ActionResult AddComment()
        //{
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddComment(Comment comment, int SchoolId)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        comment.UserId = User.Identity.GetUserId();
        //        comment.C_Date = DateTime.Now;
        //        comment.School_id = (int)Session["Sc_id"];
        //        db.Comments.Add(comment);
        //        db.SaveChanges();

        //    }
        //    return RedirectToAction("Details");
        //}




        //// GET: Schools/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}


        //// POST: Schools/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Sc_id,Sc_Name,Sc_Details,Sc_Facebook,Sc_Twitter,Sc_instagram,Sc_Image,Sc_Category,Sc_Fees_From,Sc_Fees_To,Sc_Location,Sc_phone1,Sc_phone2,Sc_phone3")] Schools schools)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Schools.Add(schools);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(schools);
        //}


        // GET: Schools/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Schools schools = db.Schools.Find(id);
        //    if (schools == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(schools);
        //}

        //// POST: Schools/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Sc_id,Sc_Name,Sc_Details,Sc_Facebook,Sc_Twitter,Sc_instagram,Sc_Image,Sc_Category,Sc_Fees_From,Sc_Fees_To,Sc_Location,Sc_phone1,Sc_phone2,Sc_phone3")] Schools schools)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(schools).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(schools);
        //}

        //// GET: Schools/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Schools schools = db.Schools.Find(id);
        //    if (schools == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(schools);
        //}

        //// POST: Schools/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Schools schools = db.Schools.Find(id);
        //    db.Schools.Remove(schools);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}


