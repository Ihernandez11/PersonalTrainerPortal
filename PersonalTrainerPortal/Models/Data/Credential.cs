using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTrainerPortal.Models.Data
{
    public class Credential
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string School { get; set; }
        public string SchoolLocation { get; set; }
        //Month and Year
        public string GraduationYear { get; set; }
        public int PersonalTrainerID { get; set; }

    }
}