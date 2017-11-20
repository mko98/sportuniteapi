using System.Collections.Generic;
using SportUnite.Domain.Models;

namespace SportUnite.DAL
{
    public interface ISportComplexRepository
    {
        IEnumerable<SportComplex> SportComplex { get; }

        void DeleteSportComplex(SportComplex sportComplex);

        bool Save();

        void SaveSportComplex(SportComplex sportComplex);
    }
}