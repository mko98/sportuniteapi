using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportUnite.Domain.Models
{
    public class SportEvent
    {
        public int SportEventId { get; set; }

        [Required(ErrorMessage = "Evenement naam mag niet leeg zijn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Evenement prijs mag niet leeg zijn")]
        public decimal? Price { get; set; }
        
        public virtual SportHall SportHall { get; set; }
        
        public virtual Sport Sport { get; set; }

        public bool Availability { get; set; }
    }
}
