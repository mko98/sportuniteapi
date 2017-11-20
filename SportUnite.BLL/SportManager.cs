using System.Collections.Generic;
using System.Linq;
using SportUnite.DAL;
using SportUnite.Domain.Models;

namespace SportUnite.BLL
{
    public class SportManager : IManager<Sport>
    {
        private ISportRepository sportRepository;

        public SportManager(ISportRepository sportRepository)
        {
            this.sportRepository = sportRepository;
        }

        public bool Delete(Sport sport)
        {
            sportRepository.DeleteSport(sport);
            return sportRepository.Save();
        }

        public IEnumerable<Sport> Get()
        {
            return sportRepository.Sports;
        }

        public Sport Get(int sportId)
        {
            return sportRepository.Sports.Where(s => s.SportId == sportId).FirstOrDefault();
        }

        public bool Save(Sport sport)
        {
            sportRepository.SaveSport(sport);
            return sportRepository.Save();
        }
    }
}
