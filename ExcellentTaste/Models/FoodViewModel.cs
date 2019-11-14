using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcellentTaste.Models
{
    public class FoodViewModel
    {
        [Required(ErrorMessage = "Vul een naam in")]
        [DataType(DataType.Text)]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vul een omschrijving in")]
        [DataType(DataType.Text)]
        [Display(Name = "Omschrijving")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Vul een prijs in")]
        [DataType(DataType.Currency)]
        [Display(Name = "Prijs")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Kies een categorie")]
        [Display(Name = "Categorie")]
        public FoodType FoodType { get; set; }

        [Display(Name = "Opties")]
        public ICollection<FoodOption> FoodOptions { get; set; }
    }
}