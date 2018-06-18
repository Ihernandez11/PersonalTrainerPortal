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

            if (personalTrainer == null)
            {
                return HttpNotFound();
            }
            //personalTrainer.Credentials = db.Credentials.Where(c => c.PersonalTrainerID == personalTrainer.ID).ToList();
            //personalTrainer.Offerings = db.Offerings.Where(o => o.PersonalTrainerID == personalTrainer.ID).ToList();

            return View(personalTrainer);
        }


        public ActionResult Clients(string UID)
        {
            if (UID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PersonalTrainer personalTrainer = db.PersonalTrainers.Where(p => p.UserID == UID).SingleOrDefault();
            if (personalTrainer == null)
            {
                return HttpNotFound();
            }
            List<Client> clients = db.Clients.Where(c => c.PersonalTrainerID == personalTrainer.UserID).ToList();

            return View(clients);
        }

        public ActionResult Details(string UID, string clientID)
        {
            if (UID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (clientID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PersonalTrainer personalTrainer = db.PersonalTrainers.Where(p => p.UserID == UID).SingleOrDefault();
            //Return the client by the clientID passed
            Client client = db.Clients.Where(c => c.UserID == clientID).SingleOrDefault();

            if (personalTrainer == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        public ActionResult Remove(string UID, string clientID)
        {
            if (UID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (clientID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PersonalTrainer personalTrainer = db.PersonalTrainers.Where(p => p.UserID == UID).SingleOrDefault();
            //Return the client by the clientID passed
            Client client = db.Clients.Where(c => c.UserID == clientID).SingleOrDefault();

            if (personalTrainer == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveConfirmed(string UID, string clientID)
        {
            PersonalTrainer personalTrainer = db.PersonalTrainers.Where(p => p.UserID == UID).SingleOrDefault();
            Client client = db.Clients.Where(c => c.UserID == clientID).SingleOrDefault();

            client.PersonalTrainerID = null;
            db.SaveChanges();

            return RedirectToAction("Clients", new {  UID });
        }

        public ActionResult Exercises(string UID)
        {
            if (UID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            

            PersonalTrainer personalTrainer = db.PersonalTrainers.Where(p => p.UserID == UID).SingleOrDefault();
            //Return the client by the clientID passed
            List<Exercise> exercises = new List<Exercise>();
            exercises = db.Exercises.Where(e => e.PersonalTrainerID == UID).ToList();

            //Get Workouts to Return Model
            if (personalTrainer == null)
            {
                return HttpNotFound();
            }

            return View(exercises);
        }

    }
}