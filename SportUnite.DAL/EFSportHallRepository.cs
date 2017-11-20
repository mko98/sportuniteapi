using System.Collections.Generic;
using System.Linq;
using SportUnite.Domain.Models;

namespace SportUnite.DAL
{
    public class EFSportHallRepository : ISportHallRepository
    {
        private AppEventEntityDbContext context;

        public EFSportHallRepository(AppEventEntityDbContext ctx)
        {
            context = ctx;
        }

        public void DeleteSportHall(SportHall sporthall)
        {
            context.SportHall.Remove(sporthall);
            context.SaveChanges();
        }

        public IEnumerable<SportHall> SportHalls => context.SportHall;

        public bool Save()
        {
            return context.SaveChanges() >= 0;
        }

        public void SaveSportHall(SportHall sportHall)
        {
            if (sportHall.SportHallId == 0)
            {
                context.SportHall.Add(sportHall);
            }
            else
            {
                SportHall dbEntry = context.SportHall
                    .FirstOrDefault(p => p.SportHallId == sportHall.SportHallId);
                if (dbEntry != null)
                {
                    dbEntry.Name = sportHall.Name;
                    dbEntry.MaxPerson = sportHall.MaxPerson;
                    dbEntry.MinPerson = sportHall.MinPerson;
                    dbEntry.SportComplex = sportHall.SportComplex;
                    dbEntry.Availability = sportHall.Availability;
                }
            }
            context.SaveChanges();
        }
    }
}