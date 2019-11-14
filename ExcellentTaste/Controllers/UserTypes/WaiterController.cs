using ExcellentTaste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcellentTaste.Controllers.UserTypes
{
    [Authorize(Roles = "Admin, Waiter")]
    public class WaiterController : BaseController
    {
        // GET: Waiter
        public ActionResult Index()
        {
            return View();
        }
    }
}