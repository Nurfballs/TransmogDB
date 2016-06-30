using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransmogDB.Models
{
    public class TransmogPopularItem
    {
        public int ItemCount { get; set; }
        public string Name { get; set; }
        public int ItemID { get; set; }

        //public TransmogPopularItem(int _itemCount, string _name, int _itemID)
        //{
        //    ItemCount = _itemCount;
        //    Name = _name;
        //    ItemID = _itemID;
        //}
    }
}
