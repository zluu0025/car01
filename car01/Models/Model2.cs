namespace car01.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=MockdataModel2")
        {
        }

        public virtual DbSet<MOCK_DATA> MOCK_DATA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MOCK_DATA>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<MOCK_DATA>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<MOCK_DATA>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<MOCK_DATA>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<MOCK_DATA>()
                .Property(e => e.ip_address)
                .IsUnicode(false);
        }
    }
}
