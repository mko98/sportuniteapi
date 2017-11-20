using System.Collections.Generic;
using System.Linq;
using SportUnite.Domain.Models;

namespace SportUnite.DAL
{
    public class EFSportEventRepository : ISportEventRepository
    {
        private AppEventEntityDbContext context;

        public EFSportEventRepository(AppEventEntityDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<SportEvent> SportEvents => context.SportEvent;

        public void DeleteSportEvent(SportEvent sportEvent)
        {
            context.SportEvent.Remove(sportEvent);
            context.SaveChanges();
        }

        public bool Save()
        {
            return context.SaveChanges() >= 0;
        }

        public void SaveSportEvent(SportEvent sportsEvent)
        {
            if (sportsEvent.SportEventId == 0)

            {
                context.SportEvent.Add(sportsEvent);
            }
            else
            {
                SportEvent dbEntry = context.SportEvent
                    .FirstOrDefault(p => p.SportEventId == sportsEvent.SportEventId);
                if (dbEntry != null)
                {
                    dbEntry.Name = sportsEvent.Name;
                    dbEntry.Price = sportsEvent.Price;
                    dbEntry.SportHall = sportsEvent.SportHall;
                    dbEntry.Sport = sportsEvent.Sport;
                    dbEntry.Availability = sportsEvent.Availability;
                }
            }
            context.SaveChanges();
        }
    }
}