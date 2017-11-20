using System.Collections.Generic;
using System.Linq;
using SportUnite.DAL;
using SportUnite.Domain.Models;

namespace SportUnite.BLL
{
    public class SportEventManager : IManager<SportEvent>
    {
        private ISportEventRepository sportEventRepository;

        public SportEventManager(ISportEventRepository sportEventRepository)
        {
            this.sportEventRepository = sportEventRepository;
        }

        public bool Delete(SportEvent sportEvent)
        {
            sportEventRepository.DeleteSportEvent(sportEvent);
            return sportEventRepository.Save();
        }

        public IEnumerable<SportEvent> Get()
        {
            return sportEventRepository.SportEvents;
        }

        public SportEvent Get(int sportEventId)
        {
            return sportEventRepository.SportEvents.Where(s => s.SportEventId == sportEventId).FirstOrDefault();
        }

        public bool Save(SportEvent sportEvent)
        {
            sportEventRepository.SaveSportEvent(sportEvent);
            return sportEventRepository.Save();
        }
    }
}
