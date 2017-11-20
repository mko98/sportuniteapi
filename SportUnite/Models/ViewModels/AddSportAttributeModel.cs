using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SportUnite.Domain.Models;

namespace SportUnite.WEBUI.Models.ViewModels
{
    public class AddSportAttributeModel
    {
        public IEnumerable<Sport> Sports { get; set; }

        [Required(ErrorMessage = "Selecteer een sport")]
        public int? SportId { get; set; }

        public SportAttribute SportAttribute { get; set; }
    }
}
