using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportUnite.Domain.Models
{
    public class SportAttributeDto
    {

        public int SportAttributeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool NotUsable { get; set; }

        public bool Availability { get; set; }


    }
}
