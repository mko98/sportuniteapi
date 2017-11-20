using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportUnite.Domain.Models
{
    public class InvoiceDto
    {

        public int InvoiceId { get; set; }

        public string Name { get; set; }

        public bool Availability { get; set; }

        public virtual SportComplex SportComplex { get; set; }
    }
}
