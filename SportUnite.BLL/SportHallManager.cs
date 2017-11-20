using System.Collections.Generic;
using System.Linq;
using SportUnite.DAL;
using SportUnite.Domain.Models;

namespace SportUnite.BLL
{
    public class SportHallManager : IManager<SportHall>
    {
        private ISportHallRepository sportHallRepository;

        public SportHallManager(ISportHallRepository sportHallRepository)
        {
            this.sportHallRepository = sportHallRepository;
        }

        public bool Delete(SportHall sportHall)
        {
            sportHallRepository.DeleteSportHall(sportHall);
            return sportHallRepository.Save();
        }

        public SportHall Get(int sportHallId)
        {
            return sportHallRepository.SportHalls.Where(s => s.SportHallId == sportHallId).FirstOrDefault();
        }

        public IEnumerable<SportHall> Get()
        {
            return sportHallRepository.SportHalls;
        }

        public bool Save(SportHall sportHall)
        {
            sportHallRepository.SaveSportHall(sportHall);
            return sportHallRepository.Save();
        }
    }
}
