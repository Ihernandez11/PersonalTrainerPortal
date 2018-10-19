using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        // GET: PersonalTrainer
        public ActionResult Index(string UID)
        {
            //ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            

            ViewBag.UserLoggedIn = true;

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
            ViewBag.UserLoggedIn = true;

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

        public ActionResult Workout(string UID, string CID)
        {
            ViewBag.UserLoggedIn = true;

            if (UID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (CID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            PersonalTrainer personalTrainer = db.PersonalTrainers.Where(p => p.UserID == UID).SingleOrDefault();
            //Return the client by the clientID passed
            Client client = db.Clients.Where(c => c.UserID == CID).SingleOrDefault();

            //Add all exercises tied to the personal trainer
            List<Exercise> exercises = db.Exercises.Where(e => e.PersonalTrainerID == UID).ToList();

            ManageWorkoutViewModel mwvm = new ManageWorkoutViewModel()
            {
                PersonalTrainerID = personalTrainer.UserID,
                ClientID = client.UserID,
                ClientFirstName = client.FirstName,
                ClientLastName = client.LastName,
                ClientEmail = client.Email,
                ClientPhoneNumber = client.PhoneNumber
            };


            return View(mwvm);
        }

        public ActionResult GetExercises(string UID)
        {

            PersonalTrainer personalTrainer = db.PersonalTrainers.Where(p => p.UserID == UID).SingleOrDefault();
            //Get Workouts to Return Model
            if (personalTrainer == null)
            {
                return Json(new { errorMessage = "No Personal Trainer has been found" });
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
                            PersonalTrainerID = e.PersonalTrainerID,
                            NullVideoInd = false
                        };

                        evmList.Add(evm);
                    }

                    if (video == null)
                    {
                        ExerciseViewModel evm = new ExerciseViewModel()
                        {
                            ExerciseID = e.ID,
                            ExerciseTitle = e.Title,
                            ExerciseDescription = e.Description,
                            PersonalTrainerID = e.PersonalTrainerID,
                            NullVideoInd = true
                        };

                        evmList.Add(evm);
                    }
                }

            }

            return Json(evmList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Details(string UID, string clientID)
        {

            ViewBag.UserLoggedIn = true;

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
            ViewBag.UserLoggedIn = true;


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
            ViewBag.UserLoggedIn = true;

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
                            PersonalTrainerID = e.PersonalTrainerID,
                            NullVideoInd = false
                        };

                        evmList.Add(evm);
                    }

                    if (video == null)
                    {
                        ExerciseViewModel evm = new ExerciseViewModel()
                        {
                            ExerciseID = e.ID,
                            ExerciseTitle = e.Title,
                            ExerciseDescription = e.Description,
                            PersonalTrainerID = e.PersonalTrainerID,
                            NullVideoInd = true
                        };

                        evmList.Add(evm);
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

            if (exercise.VideoTitle != null && exercise.VideoURL == null)
            {
                ModelState.AddModelError("", "Please enter a Video URL");
            }

            //If success - return JSON with success. JS will do the Get to reload the page
            if (ModelState.IsValid)
            {
                //create Exercise Instance
                Exercise newExercise = new Exercise()
                {
                    Title = exercise.ExerciseTitle,
                    Description = exercise.ExerciseDescription,
                    PersonalTrainerID = UID
                };

                db.Exercises.Add(newExercise);
                db.SaveChanges();

                //Need to make Video not required
                if (exercise.VideoTitle != null)
                {
                    //Create Video Instance
                    Video newVideo = new Video()
                    {
                        Title = exercise.VideoTitle,
                        ExerciseID = newExercise.ID,
                        URL = exercise.VideoURL
                    };
                    //Store in DB
                    db.Videos.Add(newVideo);
                    db.SaveChanges();
                }

                return Json(new { createStatus = "success", UID });
            }


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

        [HttpPost]
        public ActionResult AddToWorkout(ManageWorkoutViewModel exercise)
        {
            Exercise newExercise = db.Exercises.Where(e => e.PersonalTrainerID == exercise.PersonalTrainerID && e.Title == exercise.ExerciseTitle).FirstOrDefault();

            Workout workout = new Workout()
            {
                ExerciseID = newExercise.ID,
                Title = exercise.ExerciseTitle,
                Date = exercise.ExerciseDate,
                Instructions = exercise.ExerciseInstructions,
                RepCount = Convert.ToInt32(exercise.ExerciseRepCount),
                SetCount = Convert.ToInt32(exercise.ExerciseSetCount),
                ClientID = exercise.ClientID,
                PersonalTrainerID = exercise.PersonalTrainerID
            };

            db.Workouts.Add(workout);
            db.SaveChanges();

            string UID = exercise.PersonalTrainerID;
            string CID = exercise.ClientID;

            return RedirectToAction("Workout", new { UID, CID });
        }

        public ActionResult GetWorkout(string UID, string CID)
        {
            //If UID is null - return 404
            //Need to reurn a List of Workouts ordered by date
            List<Workout> workouts = db.Workouts.Where(w => w.PersonalTrainerID == UID && w.ClientID == CID).ToList();

            workouts = workouts.OrderByDescending(w => w.Date).ToList();

            return Json(workouts, JsonRequestBehavior.AllowGet);
        }

    }
}