using ExcellentTaste.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcellentTaste.Controllers.UserTypes
{
    public class AdminController : BaseController
    {
        //DataBases
        ExcellentTasteContext ETContext = new ExcellentTasteContext();

        //OnLoad Event


        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //GET: CreateFood
        public ActionResult CreateFood()
        {
            return View();
        }

        //GET: CreateFood
        [HttpPost]
        public ActionResult CreateFood(Food tempFood)
        {

            ETContext.Foods.Add(tempFood);
            return View();
        }
    }
}