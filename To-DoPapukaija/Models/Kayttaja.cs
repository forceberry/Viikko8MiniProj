namespace To_DoPapukaija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kayttaja")]
    public partial class Kayttaja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kayttaja()
        {
            Tehtava = new HashSet<Tehtava>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Etunimi { get; set; }

        [Required]
        [StringLength(50)]
        public string Sukunimi { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        public string Salasana { get; set; }

        [StringLength(500)]
        public string Kuvaus { get; set; }

        [Column(TypeName = "image")]
        public byte[] Kuva { get; set; }

        public int? Viikkotavoite { get; set; }

        public int Kayttajaryhma { get; set; }

        //private int _kayttajaRyhma;

        //public int Kayttajaryhma
        //{
        //    get { return _kayttajaRyhma; }
        //    set { _kayttajaRyhma = value; }
        //}



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tehtava> Tehtava { get; set; }
    }
}
