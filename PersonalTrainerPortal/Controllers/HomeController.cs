using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PersonalTrainerPortal.Models;
using PersonalTrainerPortal.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PersonalTrainerPortal.Controllers
{
    

    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ActionResult Index()
        {
            return View();
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                //The ?? operator is called the null-coalescing operator. It returns the left-hand operand 
                //if the operand is not null; otherwise it returns the right hand operand.
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        [HttpPost]
        public async Task<ActionResult> LoginUser(LoginViewModel user)
        {
            //Check if the modelstate is valid. If it is not valid, we will return a json object that provides the 
            //error state and error message that angularjs will populate on the page
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                ViewBag.LoginButtonError = "true";
                return Json(new { ModelState });
            }

            var result = await SignInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, shouldLockout: false);

            //Create an instance of the loggedInUser to capture the ID to send via the get
            ApplicationUser loggedInUser = new ApplicationUser();
            if (SignInStatus.Success==0)
            {
                loggedInUser = db.Users.Where(u => u.Email == user.Email).SingleOrDefault();
            }

            switch (result)
            {
                case SignInStatus.Success:
                    //Return JSon to the angular module and then do a get with the user id parameter
                    //return RedirectToAction("Index", "PersonalTrainer", new { userID = loggedInUser.Id});
                    return Json(new { signInStatus = "success", UID = loggedInUser.Id });

                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    ViewBag.LoginButtonError = "true";
                    //return View("Index", user);
                    return Json(new { signInStatus = "fail", user });
            }
        }

       

        [HttpPost]
        public async Task<ActionResult> RegisterUser(RegisterViewModel user)
        {
            if (user.FirstName == null)
            {
                ModelState.AddModelError("", "Please enter a First Name");
                return Json(new
                {
                    ModelState.Values, registerStatus = "modelfail"
                });
            }

            if (user.LastName == null)
            {
                ModelState.AddModelError("", "Please enter a Last Name");
                return Json(new
                {
                    ModelState.Values,
                    registerStatus = "modelfail"
                });
            }

            if (ModelState.IsValid)
            {
                var appUser = new ApplicationUser { UserName = user.Email, Email = user.Email };
                

                var result = await UserManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(appUser, isPersistent: false, rememberBrowser: false);

                    //Create Personal Trainer record
                    //Will need to add a checkbox to capture the user type

                    PersonalTrainer personalTrainer = new PersonalTrainer()
                    {
                        UserID = appUser.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = appUser.Email

                    };
                    db.PersonalTrainers.Add(personalTrainer);
                    db.SaveChanges();

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    ApplicationUser newUser = new ApplicationUser();
                    newUser = db.Users.Where(u => u.Email == user.Email).SingleOrDefault();

                    return Json(new { registerStatus = "success", UID = newUser.Id });
                }
                
                if (!result.Succeeded)
                {
                    AddErrors(result);
                    return Json(new { registerStatus = "fail", result, user });
                }
                
            }

            ViewBag.RegisterButtonError = "true";
            // If we got this far, something failed, redisplay form
            return Json(new { registerStatus = "fail", user });
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}