using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ExcellentTaste.Models
{
    public enum FoodType
    {
        [Display(Name = "Dranken")] Drinks = 1,
        [Display(Name = "Voorgerecht")] Starters = 2,
        [Display(Name = "Hoofdgerecht")] MainDish = 3,
        [Display(Name = "Nagerechten")] Desserts = 4,
    }
    public class Food
    {
        public Food()
        {
            this.FoodOptions = new HashSet<FoodOption>();
            
        }
        [Key]
        public int FoodId { get; set; }

        [Required(ErrorMessage = "Vul een naam in")]
        [DataType(DataType.Text)]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Omschrijving")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Vul een prijs in")]
        [DataType(DataType.Currency)]
        [Display(Name = "Prijs")]
        [DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Kies een categorie")]
        [Display(Name = "Categorie")]
        public FoodType FoodType { get; set; }

        [Required]
        [Display(Name = "Is Warm")]
        public bool Hot { get; set; }

        public bool Active { get; set; }
        [Display(Name = "Opties")]
        public virtual ICollection<FoodOption> FoodOptions { get; set; }
        public virtual ICollection<FoodOrder> FoodOrders { get; set; }

        public SelectList SelectListFoodOptions()
        {
            var tempSelectItemList = new List<SelectListItem>();
            foreach (var item in FoodOptions)
            {
                tempSelectItemList.Add( new SelectListItem { Text = item.Option, Value = item.FoodOptionId.ToString() });
            }
            var TempSelectList = new SelectList(tempSelectItemList,"Value","Text");
            return TempSelectList;
        }

    }
}