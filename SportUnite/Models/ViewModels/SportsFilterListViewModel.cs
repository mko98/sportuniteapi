using System.Collections.Generic;
using SportUnite.Domain.Models;

namespace SportUnite.WEBUI.Models.ViewModels
{
    public class SportsFilterListViewModel
    {
        public IEnumerable<Sport> Sports { get; set; }
        //        public PagingInfo PagingInfo { get; set; }
        public bool CurrentAvailability { get; set; }
    }
}
