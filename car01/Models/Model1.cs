namespace car01.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Car01Model")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<CarsSet> CarsSets { get; set; }
        public virtual DbSet<LocationSet> LocationSets { get; set; }
        public virtual DbSet<Order_Car_LineSet> Order_Car_LineSet { get; set; }
        public virtual DbSet<OrdersSet> OrdersSets { get; set; }
        public virtual DbSet<Return_RecordsSet> Return_RecordsSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<CarsSet>()
                .HasMany(e => e.Order_Car_LineSet)
                .WithRequired(e => e.CarsSet)
                .HasForeignKey(e => e.CarsCar_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LocationSet>()
                .HasMany(e => e.CarsSets)
                .WithRequired(e => e.LocationSet)
                .HasForeignKey(e => e.LocationLocatio_Id1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LocationSet>()
                .HasMany(e => e.Return_RecordsSet)
                .WithRequired(e => e.LocationSet)
                .HasForeignKey(e => e.Return_Location_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrdersSet>()
                .HasMany(e => e.Order_Car_LineSet)
                .WithRequired(e => e.OrdersSet)
                .HasForeignKey(e => e.OrdersOrder_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrdersSet>()
                .HasMany(e => e.Return_RecordsSet)
                .WithRequired(e => e.OrdersSet)
                .HasForeignKey(e => e.OrdersOrder_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
