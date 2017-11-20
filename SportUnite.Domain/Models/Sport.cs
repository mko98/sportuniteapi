using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportUnite.Domain.Models
{
    public class Sport
    {
        public Sport()
        {
            SportEvents = new HashSet<SportEvent>();
            SportSportAttributes = new HashSet<SportSportAttribute>();
        }

        public int SportId { get; set; }

        [Required(ErrorMessage = "Sportnaam mag niet leeg zijn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Beschrijving mag niet leeg zijn")]
        public string Description { get; set; }

        public bool Availability { get; set; }

        public virtual ICollection<SportEvent> SportEvents { get; set; }

        public virtual ICollection<SportSportAttribute> SportSportAttributes { get; set; }
    }
}
