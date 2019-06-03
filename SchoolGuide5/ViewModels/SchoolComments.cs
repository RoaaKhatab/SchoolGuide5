using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolGuide5.Models;

namespace SchoolGuide5.ViewModels
{
    public class SchoolComments
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Schools School { get; set; }
       
        public  List<Comment> Comment { get; set; }
        

    }
}