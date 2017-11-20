using System.Collections.Generic;
using System.Linq;
using SportUnite.DAL;
using SportUnite.Domain.Models;

namespace SportUnite.BLL
{
    public class SportComplexManager : IManager<SportComplex>
    {
        private ISportComplexRepository sportComplexRepository;

        public SportComplexManager(ISportComplexRepository sportComplexRepository)
        {
            this.sportComplexRepository = sportComplexRepository;
        }

        public bool Delete(SportComplex sportComplex)
        {
            sportComplexRepository.DeleteSportComplex(sportComplex);
            return sportComplexRepository.Save();
        }

        public IEnumerable<SportComplex> Get()
        {
            return sportComplexRepository.SportComplex;
        }

        public SportComplex Get(int sportComplexId)
        {
            return sportComplexRepository.SportComplex.Where(s => s.SportComplexId == sportComplexId).FirstOrDefault();
        }

        public bool Save(SportComplex sportComplex)
        {
            sportComplexRepository.SaveSportComplex(sportComplex);
            return sportComplexRepository.Save();
        }
    }
}
