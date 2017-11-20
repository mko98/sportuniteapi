using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportUnite.Domain.Models
{
    public class SportDto
    {

        public int SportId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Availability { get; set; }

        public virtual ICollection<SportEventDto> SportEvents { get; set; } = new List<SportEventDto>();


    }
}
