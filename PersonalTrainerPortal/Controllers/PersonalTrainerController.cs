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

            PersonalTrainer personalTrainer = db.PersonalTrainers.Where(p => p.UserID == UID).SingleOrDefault();

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

            return RedirectToAction("Clients", new { UID });
        }


        //GET Exercises
        public ActionResult Exercises(string UID)
        {
            if (UID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            PersonalTrainer personalTrainer = db.PersonalTrainers.Where(p => p.UserID == UID).SingleOrDefault();
            //Get Workouts to Return Model
            if (personalTrainer == null)
            {
                return HttpNotFound();
            }

            //Return the ExerciseViewModel based on the Trainer UID
            List<ExerciseViewModel> evmList = new List<ExerciseViewModel>();


            List<Exercise> exercises = new List<Exercise>();
            exercises = db.Exercises.Where(e => e.PersonalTrainerID == UID).ToList();

            //Only add to EVMList if there are exercises for that trainer in the DB
            if (exercises != null)
            {

                foreach (var e in exercises)
                {

                    Video video = db.Videos.Where(v => v.ExerciseID == e.ID).SingleOrDefault();
                    if (video != null)
                    {
                        ExerciseViewModel evm = new ExerciseViewModel()
                        {
                            ExerciseID = e.ID,
                            ExerciseTitle = e.Title,
                            ExerciseDescription = e.Description,
                            VideoTitle = video.Title,
                            VideoDescription = video.Description,
                            VideoURL = video.URL,
                            PersonalTrainerID = e.PersonalTrainerID
                        };
                        ViewBag.NullVideo = false;
                        evmList.Add(evm);
                    }

                    if(video == null)
                    {
                        ExerciseViewModel evm = new ExerciseViewModel()
                        {
                            ExerciseID = e.ID,
                            ExerciseTitle = e.Title,
                            ExerciseDescription = e.Description,
                            PersonalTrainerID = e.PersonalTrainerID
                        };
                        ViewBag.NullVideo = true;
                    }

                    

                }

            }

            //return List of EVM
            return View(evmList);
        }

        [HttpPost]
        public ActionResult CreateExercise(ExerciseViewModel exercise)
        {
            string UID = exercise.PersonalTrainerID;

            if (exercise.ExerciseTitle == null)
            {
                ModelState.AddModelError("", "Please enter a Title");
            }

            if (exercise.ExerciseDescription == null)
            {
                ModelState.AddModelError("", "Please enter a Description");
            }

            //If success - return JSON with success. JS will do the Get to reload the page
            if (ModelState.IsValid)
            {
                Exercise newExercise = new Exercise()
                {
                    Title = exercise.ExerciseTitle,
                    Description = exercise.ExerciseDescription,
                    PersonalTrainerID = UID
                };

                db.Exercises.Add(newExercise);
                db.SaveChanges();

                Video newVideo = new Video()
                {
                    Title = exercise.VideoTitle,
                    Description = exercise.VideoDescription,
                    ExerciseID = newExercise.ID,
                    URL = exercise.VideoURL
                };
                db.Videos.Add(newVideo);
                db.SaveChanges();


                return Json(new { createStatus = "success", UID });
            }

            //create Exercise Instance

            //Create Video Instance

            //Store in DB

            //If error - return Model State errors
            List<string> errors = new List<string>();
            foreach (var v in ModelState.Values)
            {
                foreach (var e in v.Errors)
                {
                    errors.Add(e.ErrorMessage);
                }
            }



            return Json(new { createStatus = "fail", errors, UID });
        }

    }
}