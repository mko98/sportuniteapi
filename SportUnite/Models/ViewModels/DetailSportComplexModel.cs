using SportUnite.Domain.Models;
using System.Collections.Generic;

namespace SportUnite.WEBUI.Models.ViewModels
        
{
    public class DetailSportComplexModel
    {

        public IEnumerable<SportHall> SportHalls { get; set; }

        public SportComplex SportComplex { get; set; }
    }
}
