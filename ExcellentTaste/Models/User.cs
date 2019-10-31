using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExcellentTaste.Models
{
    public enum UserType
    {
        [Display(Name = "Beheerder")] Admin,
        [Display(Name = "Ober")] Waiter,
        [Display(Name = "Kok")] Cook,
        [Display(Name = "Barman")] Bartender,
        [Display(Name = "Receptionist")] Receptionist,

    }
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public UserType UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Preposition { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [NotMapped]
        public string FullName { get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}