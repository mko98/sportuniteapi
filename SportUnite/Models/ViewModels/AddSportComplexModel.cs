using SportUnite.Domain.Models;

namespace SportUnite.WEBUI.Models.ViewModels
{
    public class AddSportComplexModel
    {
        public string Test { get; set; }

        public SportComplex SportComplex { get; set; }

        public SportHall SportHall { get; set; }

        public AddSportComplexModel() { }

        public AddSportComplexModel(SportComplex sportComplex)
        {
            SportComplex = sportComplex;
        }
    }
}
