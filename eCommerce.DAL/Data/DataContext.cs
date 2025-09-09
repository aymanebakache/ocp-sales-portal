using eCommerce.DAL.Migrations;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DAL.Data
{
    public class DataContext : DbContext
    {
        /// <summary>
        ///  You can either pass the Name of a conection string(e.g. from a web.config) and explicitly declare inside
        /// </summary>
        public DataContext() : base("DefaultConnection")
        {
            // Utiliser l'initialiseur de données OCP
            Database.SetInitializer(new OCPDataInitializer());
            
            // Configuration de l'encodage
            this.Database.CommandTimeout = 30;
            this.Configuration.LazyLoadingEnabled = false;
        }

        /// <summary>
        /// Any entity to be persisted must be declared here.
        /// </summary>
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configuration pour les catégories OCP
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
                
            modelBuilder.Entity<Product>()
                .HasOptional(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
                
            base.OnModelCreating(modelBuilder);
        }
    }
}
