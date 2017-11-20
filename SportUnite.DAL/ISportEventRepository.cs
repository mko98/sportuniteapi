using System;
using System.Collections.Generic;
using System.Text;
using SportUnite.Domain;
using SportUnite.Domain.Models;

namespace SportUnite.DAL
{
    public interface ISportEventRepository
    {
        IEnumerable<SportEvent> SportEvents { get; }

        void DeleteSportEvent(SportEvent sportEvent);

        bool Save();

        void SaveSportEvent(SportEvent sportEvent);
    }
}


