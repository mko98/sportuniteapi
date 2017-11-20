using System;
using System.Collections.Generic;
using System.Text;
using SportUnite.Domain;
using SportUnite.Domain.Models;

namespace SportUnite.DAL
{
    public interface ISportRepository
    {
        IEnumerable<Sport> Sports { get; }

        void DeleteSport(Sport sport);

        bool Save();

        void SaveSport(Sport sport);
    }
}