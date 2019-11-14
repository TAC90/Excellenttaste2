﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcellentTaste.Controllers.UserTypes
{
    [Authorize(Roles = "Admin, Receptionist")]

    public class ReceptionistController : BaseController
    {
        // GET: Receptionist
        public ActionResult Index()
        {
            return View();
        }
    }
}