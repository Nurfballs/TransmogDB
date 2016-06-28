namespace TransmogDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.Serialization;
    public class TransmogDataContext : DbContext
    {
        // Your context has been configured to use a 'TransmogDataContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TransmogDB.Models.TransmogDataContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TransmogDataContext' 
        // connection string in the application configuration file.
        public TransmogDataContext()
            : base("name=TransmogDataContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Transmog> Transmogs { get; set; }
         public virtual DbSet<TransmogItem> Items { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    [Serializable]
    [DataContract]
    [Table("Transmogs")]
    public class Transmog
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public string Realm { get; set; }

        [DataMember]
        [Required]
        public string Race { get; set; }

        [DataMember]
        [Required]
        public string Gender { get; set; }

        [DataMember]
        [Required]
        public string Class { get; set; }

        [DataMember]
        [Required]
        public string Image { get; set; }

        [DataMember]
        [Required]
         public List<TransmogItem> Items { get; set; }
        // public virtual List<TransmogItem> Items { get; set; }


    }

    //[Table("TransmogItems")]
    //public class TransmogItem
    //{
    //    public enum SlotType { BACK, CHEST, FEET, HEAD, HANDS, LEGS, MAINHAND, OFFHAND, RANGED, SHIRT, SHOULDER, WAIST, WRIST };
    //    public int ID { get; set; }

    //    public int TransmogID { get; set; }

    //    public string Name { get; set; }

    //    public bool Transmogrified { get; set; }

    //    public SlotType Slot { get; set; }

    //    //public virtual List<Transmog> Transmog { get; set; }
    //}

}