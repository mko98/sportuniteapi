using System.Collections.Generic;
using System.Linq;
using SportUnite.Domain.Models;

namespace SportUnite.DAL
{
    public class EFSportAttributeRepository : ISportAttributeRepository
    {
        private AppEventEntityDbContext context;

        public EFSportAttributeRepository(AppEventEntityDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<SportAttribute> SportAttributes => context.SportAttribute;

        public void DeleteSportAttribute(SportAttribute sportAttribute)
        {
            context.SportAttribute.Remove(sportAttribute);
            context.SaveChanges();
        }

        public bool Save()
        {
            return context.SaveChanges() >= 0;
        }

        public void SaveSportAttribute(SportAttribute sportAttribute)
        {
            if (sportAttribute.SportAttributeId == 0)

            {
                context.SportAttribute.Add(sportAttribute);
            }
            else
            {
                SportAttribute dbEntry = context.SportAttribute
                    .FirstOrDefault(p => p.SportAttributeId == sportAttribute.SportAttributeId);
                if (dbEntry != null)
                {
                    dbEntry.SportAttributeId = sportAttribute.SportAttributeId;
                    dbEntry.Name = sportAttribute.Name;
                    dbEntry.Description = sportAttribute.Description;
                    dbEntry.NotUsable = sportAttribute.NotUsable;
                    dbEntry.Availability = sportAttribute.Availability;

                }
            }
            context.SaveChanges();
        }
    }
}