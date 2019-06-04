using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolGuide5.Models;
using System.Net;
using System.Net.Mail;


namespace SchoolGuide5.Controllers
{
    public class EmailSetupController : Controller
    {
        // GET: EmailSetup
        public ActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(gmail model)
        {
            MailMessage mm = new MailMessage("feedback.schools1@gmail.com ", "nadiinne.schools1@gmail.com");
            mm.Subject = "Feedback / Question";
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("feedback.schools1@gmail.com", "Feedback@schools");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "your Feedback / Question has been sent succefully";

            return View();
        }
    }
}