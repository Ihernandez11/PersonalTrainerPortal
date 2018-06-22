using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTrainerPortal.Models
{
    public class ExerciseViewModel
    {
        
        public string ExerciseTitle { get; set; }
        
        public string ExerciseDescription { get; set; }
        
        public string PersonalTrainerID { get; set; }

        public string VideoTitle { get; set; }
        
        public string VideoDescription { get; set; }
        
        public string VideoURL { get; set; }

        public int ExerciseID { get; set; }

    }
}