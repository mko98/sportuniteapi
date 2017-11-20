using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportUnite.Domain.Models
{
    public class SportAttribute
    {
        public SportAttribute()
        {
            SportSportAttributes = new HashSet<SportSportAttribute>();
        }

        public int SportAttributeId { get; set; }

        [Required(ErrorMessage = "Sportattribuut naam mag niet leeg zijn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Beschrijving mag niet leeg zijn")]
        public string Description { get; set; }

        public bool NotUsable { get; set; }

        public bool Availability { get; set; }

        public virtual ICollection<SportSportAttribute> SportSportAttributes { get; set; }
    }
}
