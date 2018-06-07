using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalTrainerPortal.Models.Data
{
    public class Comment
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public int BlogPostID { get; set; }


    }
}