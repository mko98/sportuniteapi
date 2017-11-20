using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportUnite.Domain.Models
{
    public class SportComplex
    {
        public SportComplex()
        {
            Invoices = new HashSet<Invoice>();
            SportHalls = new HashSet<SportHall>();
        }

        public int SportComplexId { get; set; }
        [Required(ErrorMessage = "Sportcomplex naam mag niet leeg zijn")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Adres niet leeg zijn")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Stad mag niet leeg zijn")]
        public string City { get; set; }

        [Required(ErrorMessage = "Postcode mag niet leeg zijn")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Huisnummer mag niet leeg zijn")]
        public string HouseNumber { get; set; }

        public bool Availability { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }

        public virtual ICollection<SportHall> SportHalls { get; set; }
    }
}
