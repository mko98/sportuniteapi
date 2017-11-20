namespace SportUnite.Domain.Models
{
    public class SportEventDto
    {
        public int SportEventId { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

//        public virtual SportHall SportHall { get; set; }
//
//        public virtual Sport Sport { get; set; }

        public bool Availability { get; set; }
    }
}
