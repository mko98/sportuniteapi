using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SportUnite.Domain.Models;

namespace SportUnite.Domain.Models
{
    public class SportHallDto
    {

        public int SportHallId { get; set; }

        public string Name { get; set; }

        public int? MaxPerson { get; set; }

        public int? MinPerson { get; set; }

        public virtual SportComplex SportComplex { get; set; }

        public virtual ICollection<SportEventDto> SportEvents { get; set; } = new List<SportEventDto>();

        public bool Availability { get; set; }
    }
}
