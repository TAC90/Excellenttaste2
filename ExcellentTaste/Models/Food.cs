﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExcellentTaste.Models
{
    public enum FoodType
    {
        [Display(Name = "Koude Dranken")] ColdDrink,
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

        public bool Active { get; set; }
        public virtual ICollection<FoodOption> FoodOptions { get; set; }
        public virtual ICollection<FoodOrder> FoodOrders { get; set; }

    }
}