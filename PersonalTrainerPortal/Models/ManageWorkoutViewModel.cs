using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTrainerPortal.Models
{
    public class ManageWorkoutViewModel
    {
        //Client Data
        public string ClientID { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhoneNumber { get; set; }

        //Personal Trainer Data
        public string PersonalTrainerID { get; set; }

        ////Exercise Data
        //public int ExerciseID { get; set; }
        //public string ExerciseTitle { get; set; }
        //public string ExerciseDescription { get; set; }

        ////Video Data
        //public int VideoID { get; set; }
        //public string VideoTitle { get; set; }
        //public string VideoURL { get; set; }

    }
}