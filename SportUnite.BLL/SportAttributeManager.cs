using System.Collections.Generic;
using System.Linq;
using SportUnite.DAL;
using SportUnite.Domain.Models;

namespace SportUnite.BLL
{
    public class SportAttributeManager : IManager<SportAttribute>
    {
        private ISportAttributeRepository sportAttributeRepository;

        public SportAttributeManager(ISportAttributeRepository sportAttributeRepository)
        {
            this.sportAttributeRepository = sportAttributeRepository;
        }

        public bool Delete(SportAttribute sportAttribute)
        {
            sportAttributeRepository.DeleteSportAttribute(sportAttribute);
            return sportAttributeRepository.Save();
        }

        public IEnumerable<SportAttribute> Get()
        {
            return sportAttributeRepository.SportAttributes;
        }

        public SportAttribute Get(int sportAttributeId)
        {
            return sportAttributeRepository.SportAttributes.Where(s => s.SportAttributeId == sportAttributeId).FirstOrDefault();
        }

        public bool Save(SportAttribute sportAttribute)
        {
            sportAttributeRepository.SaveSportAttribute(sportAttribute);
            return sportAttributeRepository.Save();
        }
    }
}
