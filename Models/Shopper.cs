using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace mission10.Models
{
    public class Shopper
    {
        [Key]
        [BindNever]
        public int ShopperId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a first name:")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Please enter a last name:")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Please enter the first address line:")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter the city name:")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter the state name:")]
        public string State { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter the country:")]
        public string Country { get; set; }

        [BindNever]
        public bool OrderReceived { get; set; }

    }
}
