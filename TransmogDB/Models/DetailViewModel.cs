using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransmogDB.Models
{
    public class DetailViewModel
    {
        public Transmog Appearance { get; set; }
        public List<TransmogItem> Items { get; set; }

        public DetailViewModel(Transmog _appearance, List<TransmogItem> _items)
        {
            Appearance = _appearance;
            Items = _items;
        }
    }
}