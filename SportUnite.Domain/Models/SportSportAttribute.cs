using System;
using System.Collections.Generic;

namespace SportUnite.Domain.Models
{
    public class SportSportAttribute
    {
        public int SportId { get; set; }

        public int SportAttributeId { get; set; }

        public virtual SportAttribute SportAttribute { get; set; }

        public virtual Sport Sport { get; set; }
    }
}
