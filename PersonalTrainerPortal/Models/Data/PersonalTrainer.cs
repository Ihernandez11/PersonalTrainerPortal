using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalTrainerPortal.Models.Data
{
    public class PersonalTrainer
    {
        [Required]
        public int ID { get; set; }
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Exercise> Exercises { get; set; }
        public List<BlogPost> BlogPosts { get; set; }
        public List<Client> Clients { get; set; }
        public List<FoodItem> FoodItems { get; set; }


    }
}