namespace ORM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShawarmaModel : DbContext
    {
        public ShawarmaModel()
            : base("name=ShawarmaModel")
        {
        }

        public virtual DbSet<Ingradient> Ingradient { get; set; }
        public virtual DbSet<IngradientCategory> IngradientCategory { get; set; }
        public virtual DbSet<OrderHeader> OrderHeader { get; set; }
        public virtual DbSet<PriceController> PriceController { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<SellingPoint> SellingPoint { get; set; }
        public virtual DbSet<SellingPointCategory> SellingPointCategory { get; set; }
        public virtual DbSet<Shawarma> Shawarma { get; set; }
        public virtual DbSet<ShawarmaRecipe> ShawarmaRecipe { get; set; }
        public virtual DbSet<TimeController> TimeController { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingradient>()
                .Property(e => e.IngradientName)
                .IsUnicode(false);

            modelBuilder.Entity<IngradientCategory>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<PriceController>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Seller>()
                .Property(e => e.SellerName)
                .IsUnicode(false);

            modelBuilder.Entity<SellingPoint>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<SellingPoint>()
                .Property(e => e.ShawarmaTitile)
                .IsUnicode(false);

            modelBuilder.Entity<SellingPointCategory>()
                .Property(e => e.SellingPointCategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Shawarma>()
                .Property(e => e.ShawarmaName)
                .IsUnicode(false);
        }
    }
}
