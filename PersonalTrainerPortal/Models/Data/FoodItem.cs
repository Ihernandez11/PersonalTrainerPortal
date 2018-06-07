using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalTrainerPortal.Models.Data
{
    public class FoodItem
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
        public int ProteinGrams { get; set; }
        public int CarbGrams { get; set; }
        public int FatGrams { get; set; }
        [Required]
        public int PersonalTrainerID { get; set; }

    }
}