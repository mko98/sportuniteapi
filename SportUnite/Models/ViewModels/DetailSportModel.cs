using SportUnite.Domain.Models;
using System.Collections.Generic;

namespace SportUnite.WEBUI.Models.ViewModels

{
    public class DetailSportModel
    {

        public IEnumerable<SportAttribute> SportAttributes { get; set; }
        public SportSportAttribute SportSportAttribute { get; set; }
        public Sport Sport { get; set; }
    }
}
