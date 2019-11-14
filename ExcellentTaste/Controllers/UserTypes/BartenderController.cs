using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcellentTaste.Controllers.UserTypes
{
    [Authorize(Roles = "Admin, Bartender")]

    public class BartenderController : BaseController
    {
        // GET: Bartender
        public ActionResult Index()
        {
            return View();
        }
    }
}
