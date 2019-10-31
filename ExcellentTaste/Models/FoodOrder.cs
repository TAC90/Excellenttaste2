using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcellentTaste.Models
{
    public enum FoodStatus
    {
        //Comment
        [Display(Name = "Besteld")] Ordered,
        [Display(Name = "Mee Bezig")] InProgress,
        [Display(Name = "Gereed")] Ready,
        [Display(Name = "Geserveerd")] Delivered,
    }
    public class FoodOrder
    {
        [Key, Column(Order = 0)]
        public int FoodId { get; set; }
        [Key, Column(Order = 1)]
        public int OrderId { get; set; }

        public virtual Food Food { get; set; }
        public virtual Order Order { get; set; }

        public int Amount { get; set; }
        public FoodStatus FoodStatus { get; set; }

    }
}