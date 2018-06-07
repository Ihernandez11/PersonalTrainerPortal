using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalTrainerPortal.Models.Data
{
    public class BlogPost
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        
        public List<Image> Images { get; set; }

        public List<Comment> Comments { get; set; }
        [Required]
        public int PersonalTrainerID { get; set; }
    }
}