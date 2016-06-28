using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TransmogDB.Models
{
    public class TransmogItem
    {
        public enum SlotType { BACK, CHEST, FEET, HEAD, HANDS, LEGS, MAINHAND, OFFHAND, RANGED, SHIRT, SHOULDER, WAIST, WRIST };

        public int ID { get; set; }
        public int TransmogID { get; set; }
        public string Name { get; set; }
        public bool Transmogrified { get; set; }
        public SlotType Slot { get; set; }

        //public virtual List<Transmog> Transmog { get; set; }
        }

    }