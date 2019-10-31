using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExcellentTaste.Models
{
    public enum FoodType
    {
        [Display(Name = "Kouwe Dranken")] ColdDrink,
        [Display(Name = "Warme Dranken")] HotDrink,
        [Display(Name = "Koud Voorgerecht")] StarterCold,
        [Display(Name = "Warm Voorgerecht")] StarterHot,
        [Display(Name = "Hoofdgerecht")] MainDish,
        [Display(Name = "Warme Nagerechten")] DessertHot,
        [Display(Name = "Koude Nagerechten")] DessertCold,
    }
    public class Food
    {
        public Food()
        {
            this.FoodOptions = new HashSet<FoodOption>();
            
        }
        [Key]
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public FoodType FoodType { get; set; }
        public virtual ICollection<FoodOption> FoodOptions { get; set; }
        public virtual ICollection<FoodOrder> FoodOrders { get; set; }

    }
}