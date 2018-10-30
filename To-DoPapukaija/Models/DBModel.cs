namespace To_DoPapukaija.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<Kayttaja> Kayttaja { get; set; }
        public virtual DbSet<Tehtava> Tehtava { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kayttaja>()
                .HasMany(e => e.Tehtava)
                .WithRequired(e => e.Kayttaja)
                .WillCascadeOnDelete(false);
        }
    }
}
