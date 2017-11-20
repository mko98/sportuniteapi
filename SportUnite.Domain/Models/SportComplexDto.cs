using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportUnite.Domain.Models
{
    public class SportComplexDto
    {


        public int SportComplexId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string HouseNumber { get; set; }

        public bool Availability { get; set; }

        public virtual ICollection<InvoiceDto> Invoices { get; set; } = new List<InvoiceDto>();

        public virtual ICollection<SportHallDto> SportHalls { get; set; } = new List<SportHallDto>();

    }
}
