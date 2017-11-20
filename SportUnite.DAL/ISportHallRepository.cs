using System;
using System.Collections.Generic;
using System.Text;
using SportUnite.Domain;
using SportUnite.Domain.Models;

namespace SportUnite.DAL
{
    public interface ISportHallRepository
    {
        IEnumerable<SportHall> SportHalls { get; }

        void DeleteSportHall(SportHall sportHall);

        void SaveSportHall(SportHall sportHall);

        bool Save();
    }
}


