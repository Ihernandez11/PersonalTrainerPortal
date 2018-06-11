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
        public string UserID { get; set; }
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

        //Fields added for Portal Home Customization
        public string Slogan { get; set; }
        public string ProfileDescription { get; set; }
        public string CredentialsDescription { get; set; }
        public string ProductsDescription { get; set; }
        public List<Credential> Credentials { get; set; }
        public List<Offering> Offerings { get; set; }   

    }
}