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
        private ExcellentTasteContext ETContext = new ExcellentTasteContext();
        // GET: Waiter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateOrder(FoodType? tempFoodType)
        {
            if(tempFoodType == null) {
                return RedirectToAction("Index", CurrentUserTypeToString());
            }
            var tempFoodOrders = new List<FoodOrder>();

            foreach (var SelectedFood in ETContext.Foods.Where(food => food.Active == true))
            {
                if(SelectedFood.FoodType == tempFoodType)
                {
                    var tempFoodOrder = new FoodOrder();
                    tempFoodOrder.Food = SelectedFood;
                    tempFoodOrders.Add(tempFoodOrder);                    
                }
            }
            return View(tempFoodOrders);
        }

        [HttpPost]
        public ActionResult CreateOrder(string tempOrder)
        {
            return RedirectToAction("Index");
        }
    }
}