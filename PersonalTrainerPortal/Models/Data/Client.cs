using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalTrainerPortal.Models.Data
{
    public class Client
    {
        [Required]
        public int ID { get; set; }
        public string UserID { get; set; }
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string PersonalTrainerID { get; set; }
        

        public List<Workout> Workouts { get; set; }
        public List<Meal> Meals { get; set; }
    }
}