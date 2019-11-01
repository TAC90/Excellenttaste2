using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcellentTaste.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string GuestIP { get; set; }
        public int Table { get; set; }
        public string OberId { get; set; }
        public string ReceptionistId { get; set; }
        public ICollection<Order> Orders { get; set; }
        
    }
}