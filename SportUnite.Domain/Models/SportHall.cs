using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportUnite.Domain.Models
{
    public class SportHall
    {
        public SportHall()
        {
            SportEvents = new HashSet<SportEvent>();
        }

        public int SportHallId { get; set; }

        [Required(ErrorMessage = "Sporthal naam mag niet leeg zijn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Maximaal aantal personen mag niet leeg zijn")]
        public int? MaxPerson { get; set; }

        [Required(ErrorMessage = "Minimaal aantal personen mag niet leeg zijn")]
        public int? MinPerson { get; set; }
        
        public virtual SportComplex SportComplex { get; set; }

        public virtual ICollection<SportEvent> SportEvents { get; set; }

        public bool Availability { get; set; }
    }
}
