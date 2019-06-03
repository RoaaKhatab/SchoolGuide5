using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolGuide5.Models
{
    public class Schools
    {
        [Key]

        public int Sc_id { get; set; }

        [Required(ErrorMessage = "School Name Is required")]
        [DisplayName("School Name")]
        public string Sc_Name { get; set; }

        [DisplayName("School Details")]
        public string Sc_Details { get; set; }

        [DisplayName("Facebook")]
        public string Sc_Facebook { get; set; }

        [DisplayName("Twitter")]
        public string Sc_Twitter { get; set; }

        [DisplayName("Instagram")]
        public string Sc_instagram { get; set; }

        [DisplayName("School Picture")]
        public String Sc_Image { get; set; }

        [DisplayName("School Category")]
        public String Sc_Category { get; set; }

        [DisplayName("School Fees From")]
        public String Sc_Fees_From { get; set; }

        [DisplayName("School Fees To")]
        public String Sc_Fees_To { get; set; }


        [Required(ErrorMessage = "Location is required")]
        [DisplayName("School Location")]
        public string Sc_Location { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [DisplayName("School Phone Number 1")]
        public int Sc_phone1 { get; set; }

        [DisplayName("School Phone Number 2")]

        public int? Sc_phone2 { get; set; }

        [DisplayName("School Phone Number 3")]

        public int? Sc_phone3 { get; set; }
        public List<Comment> Comments { get; set; }

        //public virtual IList<Comment> Comments { get; set; }

        //public Schools()
        //{
        //    Comments = new List<Comment>();

        //}



    }
}