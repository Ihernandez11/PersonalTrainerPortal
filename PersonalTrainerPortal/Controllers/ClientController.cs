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
            if (UID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Client client = db.Clients.Where(c => c.UserID == UID).SingleOrDefault();

            return View(client);
        }
    }
}