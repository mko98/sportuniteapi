using System.Collections.Generic;
using System.Linq;
using SportUnite.Domain.Models;

namespace SportUnite.DAL
{
    public class EFSportRepository : ISportRepository
    {
        private AppEventEntityDbContext context;

        public EFSportRepository(AppEventEntityDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Sport> Sports => context.Sport;

        public void DeleteSport(Sport sport)
        {
            context.Sport.Remove(sport);
            context.SaveChanges();
        }

        public bool Save()
        {
            return context.SaveChanges() >= 0;
        }

        public void SaveSport(Sport sport)
        {
            if (sport.SportId == 0)
            {
                
                context.Sport.Add(sport);
            }
            else
            {
                Sport dbEntry = context.Sport
                    .FirstOrDefault(p => p.SportId == sport.SportId);
                if (dbEntry != null)
                {
                    dbEntry.Name = sport.Name;
                    dbEntry.Description = sport.Description;
                    dbEntry.Availability = sport.Availability;
                }
            }
            context.SaveChanges();
        }
    }
}