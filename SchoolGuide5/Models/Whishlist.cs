using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolGuide5.Models
{
    public class Whishlist
    {
        [Key]
        public int Whish_id { get; set; }
        public string User_id { get; set; }
        public int? SC_ID { get; set; }
        
         [ForeignKey("SC_ID")]   
        public virtual Schools School { get; set; }

    }
}