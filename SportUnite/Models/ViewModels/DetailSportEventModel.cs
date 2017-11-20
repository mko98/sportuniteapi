using SportUnite.Domain.Models;
using System.Collections.Generic;

namespace SportUnite.WEBUI.Models.ViewModels
        
{
    public class DetailSportEventModel
    {
        public IEnumerable<Sport> Sports { get; set; }

        public IEnumerable<SportHall> SportHalls { get; set; }

        public Sport Sport { get; set; }

        public SportEvent SportEvent { get; set; }

        public SportHall SportHall { get; set; }

        public SportComplex SportComplex { get; set; }

        public SportAttribute SportAttribute { get; set; }


        public DetailSportEventModel(SportEvent sportEvent, Sport sport, SportHall sportHall, SportComplex sportComplex, SportAttribute sportAttribute)
        {
            SportEvent = sportEvent;
            Sport = sport;
            SportHall = sportHall;
            SportComplex = sportComplex;
            SportAttribute = sportAttribute;
            
        }
    }
}
