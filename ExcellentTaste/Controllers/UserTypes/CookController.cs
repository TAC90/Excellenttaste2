using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcellentTaste.Controllers.UserTypes
{
    [Authorize(Roles = "Admin, Cook")]
    public class CookController : BaseController
    {
        // GET: Cook
        public ActionResult Index()
        {
            return View();
        }
    }
}