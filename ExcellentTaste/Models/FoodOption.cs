using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcellentTaste.Models
{
    public class FoodOption
    {
        public FoodOption()
        {
            this.Foods = new HashSet<Food>();

        }
        [Key]
        public int FoodOptionId { get; set; }
        public string Option { get; set; }
        public virtual ICollection<Food> Foods { get; set; }

    }
}