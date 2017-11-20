using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportUnite.Domain.Models
{
    public class Invoice
    {
        
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "Factuur naam mag niet leeg zijn")]
        public string Name { get; set; }

        public bool Availability { get; set; }

        public virtual SportComplex SportComplex { get; set; }
    }
}
