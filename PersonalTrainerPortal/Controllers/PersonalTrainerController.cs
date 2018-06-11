using PersonalTrainerPortal.Models;
using PersonalTrainerPortal.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PersonalTrainerPortal.Controllers
{
    public class PersonalTrainerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PersonalTrainer
        public ActionResult Index(string UID)
        {
            if (UID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PersonalTrainer personalTrainer = db.PersonalTrainers.Where(p=> p.UserID==UID).SingleOrDefault();
            //personalTrainer.Credentials = db.Credentials.Where(c => c.PersonalTrainerID == personalTrainer.ID).ToList();
            //personalTrainer.Offerings = db.Offerings.Where(o => o.PersonalTrainerID == personalTrainer.ID).ToList();

            return View(personalTrainer);
        }
    }
}