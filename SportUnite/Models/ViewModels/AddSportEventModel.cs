using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SportUnite.Domain.Models;

namespace SportUnite.WEBUI.Models.ViewModels
{
    public class AddSportEventModel
    {
        public IEnumerable<Sport> Sports { get; set; }

        public IEnumerable<SportHall> SportHalls { get; set; }

        [Required(ErrorMessage = "Selecteer een sport")]
        public int? SportId { get; set; }

        public SportEvent SportEvent { get; set; }

        [Required(ErrorMessage = "Kies een sporthal")]
        public int? SportHallId { get; set; } 
    }
}
