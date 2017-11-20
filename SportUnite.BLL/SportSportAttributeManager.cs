using System.Collections.Generic;
using SportUnite.DAL;
using SportUnite.Domain.Models;

namespace SportUnite.BLL
{
    public class SportSportAttributeManager : IManager<SportSportAttribute>
    {
        private ISportSportAttributeRepository sportSportAttributeRepository;

        public SportSportAttributeManager(ISportSportAttributeRepository sportSportAttributeRepository)
        {
            this.sportSportAttributeRepository = sportSportAttributeRepository;
        }

        public bool Delete(SportSportAttribute sportSportAttribute)
        {
            return false;
        }

        public IEnumerable<SportSportAttribute> Get()
        {
            return sportSportAttributeRepository.SportSportAttributes;
        }

        public SportSportAttribute Get(int id)
        {
            return null;
        }

        public bool Save(SportSportAttribute sportSportAttribute)
        {
            return false;
        }
    }
}