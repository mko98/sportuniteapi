using System.Collections.Generic;
using System.Linq;
using SportUnite.Domain.Models;

namespace SportUnite.DAL
{
    public class EFSportComplexRepository : ISportComplexRepository
    {
        private AppEventEntityDbContext context;

        public EFSportComplexRepository(AppEventEntityDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<SportComplex> SportComplex => context.SportComplex;

        public void DeleteSportComplex(SportComplex sportcomplex)
        {
            context.SportComplex.Remove(sportcomplex);
            context.SaveChanges();
        }

        public bool Save()
        {
            return context.SaveChanges() >= 0;
        }

        public void SaveSportComplex(SportComplex sportsComplex)
        {
            if (sportsComplex.SportComplexId == 0)

            {
                context.SportComplex.Add(sportsComplex);
            }
            else
            {
                SportComplex dbEntry = context.SportComplex.FirstOrDefault(p => p.SportComplexId == sportsComplex.SportComplexId);
                if (dbEntry != null)
                {
                    dbEntry.Name = sportsComplex.Name;
                    dbEntry.Address = sportsComplex.Address;
                    dbEntry.City = sportsComplex.City;
                    dbEntry.PostalCode = sportsComplex.PostalCode;
                    dbEntry.HouseNumber = sportsComplex.HouseNumber;
                    dbEntry.Availability = sportsComplex.Availability;
                }
            }
            context.SaveChanges();
        }
    }
}