using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalTrainerPortal.Models.Data
{
    public class Meal
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int FoodItemID { get; set; }
        
        public int Quantity { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public string Instructions { get; set; }
        public string ClientID { get; set; }

    }
}