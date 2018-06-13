using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTrainerPortal.Models.Data
{
    public class Offering
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PersonalTrainerID { get; set; }

    }
}