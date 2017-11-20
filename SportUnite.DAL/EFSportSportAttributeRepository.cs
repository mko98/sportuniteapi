using System.Collections.Generic;
using SportUnite.Domain.Models;

namespace SportUnite.DAL
{
    public class EFSportSportAttributeRepository : ISportSportAttributeRepository
    {
        private AppEventEntityDbContext context;

        public EFSportSportAttributeRepository(AppEventEntityDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<SportSportAttribute> SportSportAttributes => context.SportSportAttribute;
    }
}
