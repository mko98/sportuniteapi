using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SportUnite.Domain.Models;

namespace SportUnite.WEBUI.Models.ViewModels
{
    public class AddSportHallModel
    {
        public IEnumerable<SportComplex> SportComplexes { get; set; }

        [Required(ErrorMessage = "Selecteer een sportcomplex")]
        public int? SportComplexId { get; set; }

        public SportHall SportHall { get; set; }
    }
}
