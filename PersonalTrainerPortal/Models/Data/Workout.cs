using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalTrainerPortal.Models.Data
{
    public class Workout
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int RepCount { get; set; }
        public int SetCount { get; set; }
        public int TimeInterval { get; set; }
        public string Instructions { get; set; }
        public int ExerciseID { get; set; }
        public string ClientID { get; set; }
    }
}