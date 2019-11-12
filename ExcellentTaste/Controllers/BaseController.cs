using ExcellentTaste.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcellentTaste.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public ApplicationDbContext dbIdentityContext = new ApplicationDbContext();
        public BaseController() { }
        public BaseController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
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

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUser CurrentUser()
        {
            var tempId = User.Identity.GetUserId();
            var currentUser = UserManager.Users.Where(user => user.Id == tempId).FirstOrDefault();
            return currentUser;
        }

        public ApplicationUser CurrentUser(string email)
        {
            var currentUser = UserManager.Users.Where(user => user.Email == email).FirstOrDefault();
            return currentUser;
        }

        public ViewResult RedirectToIndexView()
        {
                switch (CurrentUser().UserType)
                {
                    case UserType.Bartender:
                        return View("Index", "Bartender");
                    case UserType.Cook:
                        return View("Index", "Cook");
                    case UserType.Receptionist:
                        return View("Index", "Receptionist");
                    case UserType.Waiter:
                        return View("Index", "Waiter");
                    case UserType.Admin:
                        return View("Index", "Admin");
                    default:
                        return View("Index", "Home");
                }
        }

        public string CurrentUserTypeToString()
        {
            return CurrentUser().UserType.ToString("g");
        }
        public string CurrentUserTypeToString(string email)
        {
            return CurrentUser(email).UserType.ToString("g");
        }
        public bool TypeAllowed(UserType[] type)
        {
            foreach (var userRole in type)
            {
                if (CurrentUser().UserType == userRole)
                {
                    return true;
                }
            }
            return false;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}