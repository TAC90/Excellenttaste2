using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcellentTaste.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public User Waiter { get; set; }
        public bool FoodFinished { get; set; }
        public bool DrinksFinished { get; set; }
        public virtual ICollection<FoodOrder> FoodOrders { get; set; }

    }
}