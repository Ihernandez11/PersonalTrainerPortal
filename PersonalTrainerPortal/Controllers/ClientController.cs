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
    public class ClientController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Client
        public ActionResult Index(string UID)
        {
            //Use Application Cookie from Identity model to find the UID
            if (UID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Client client = db.Clients.Where(c => c.UserID == UID).SingleOrDefault();

            return View(client);
        }

        public ActionResult GetWorkout(string UID)
        {
            //If UID is null - return 404
            //Need to reurn a List of Workouts ordered by date
            List<Workout> workouts = db.Workouts.Where(w => w.ClientID == UID).ToList();

            workouts = workouts.OrderByDescending(w => w.Date).ToList();

            return Json(workouts, JsonRequestBehavior.AllowGet);
        }
    }
}