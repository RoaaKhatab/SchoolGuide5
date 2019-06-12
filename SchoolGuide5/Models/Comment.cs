using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolGuide5.Models
{
    public class Comment
    {
        [Key]
        public int C_id { get; set; }
        public DateTime C_Date { get; set; }
        public string C_Details { get; set; }
        public string UserId { get; set; }
        public int? School_id { get; set; }
        public string Username { get; set; }
        [Range(0,5)]
        public double Rating { get; set; }

        

        //[ForeignKey("School_id")]
        //public Schools SchoolId { get; set; }

        //[ForeignKey("UserId")]
        //public virtual ApplicationUser user { get; set; }

    }
}