using System.Collections.Generic;
using SportUnite.Domain.Models;

namespace SportUnite.DAL
{
    public interface ISportSportAttributeRepository
    {
        IEnumerable<SportSportAttribute> SportSportAttributes { get; }
    }
}
