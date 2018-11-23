namespace SA47TEAM5ASPNET
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Bookshop : DbContext
    {
        public Bookshop()
            : base("name=Bookshop")
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<CartPromo> CartPromo { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryDiscount> CategoryDiscount { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(e => e.InvoiceDetails)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CartPromo>()
                .HasMany(e => e.Invoice)
                .WithRequired(e => e.CartPromo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Book)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.CategoryDiscount)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.InvoiceDetails)
                .WithRequired(e => e.Invoice)
                .WillCascadeOnDelete(false);
        }
    }
}
