using ExcellentTaste.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcellentTaste.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

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
            var currentUser = UserManager.Users.Where(id => id.Id == tempId).FirstOrDefault();
            return currentUser;
        }

        public void RedirectToIndex(bool correct)
        {
            if (!correct)
            {
                switch (CurrentUser().UserType)
                {
                    case UserType.Bartender:
                        RedirectToAction("Index", "Bartender");
                        break;
                    case UserType.Cook:
                        RedirectToAction("Index", "Cook");
                        break;
                    case UserType.Receptionist:
                        RedirectToAction("Index", "Receptionist");
                        break;
                    case UserType.Waiter:
                        RedirectToAction("Index", "Waiter");
                        break;
                    default:
                        RedirectToAction("Index", "Home");
                        break;
                }
            }
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
                default:
                    return View("Index", "Home");
            }

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