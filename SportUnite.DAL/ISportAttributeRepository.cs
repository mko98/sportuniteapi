using System.Collections.Generic;
using SportUnite.Domain.Models;

namespace SportUnite.DAL
{
    public interface ISportAttributeRepository
    {
        IEnumerable<SportAttribute> SportAttributes { get; }

        void DeleteSportAttribute(SportAttribute sportAttribute);

        bool Save();

        void SaveSportAttribute(SportAttribute sportAttribute);
    }
}