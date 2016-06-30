using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransmogDB.Models
{
    public class HomeViewModel
    {
        public List<Transmog> Appearance { get; set; }
        public List<TransmogPopularItem> PopularItems { get; set; }

        //public HomeViewModel(List<Transmog> _appearance, List<TransmogPopularItem> _popularItems)
        //{
        //    Appearance = _appearance;
        //    PopularItems = _popularItems;
            
        //}

    }


}