namespace To_DoPapukaija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tehtava")]
    public partial class Tehtava
    {
        [Required]
        [StringLength(50)]
        public string Nimi { get; set; }

        public int TehtavaID { get; set; }

        [StringLength(500)]
        public string Kuvaus { get; set; }

        public int Pisteet { get; set; }

        public int KayttajaID { get; set; }

        [Column(TypeName = "image")]
        public byte[] Kuva { get; set; }

        [Column(TypeName = "date")]
        public DateTime Aikaleima { get; set; }


        [StringLength(50)]
        public string Kategoria { get; set; }

        public bool Julkinen { get; set; }

        public bool Tehty { get; set; }

        public virtual Kayttaja Kayttaja { get; set; }
    }
}
