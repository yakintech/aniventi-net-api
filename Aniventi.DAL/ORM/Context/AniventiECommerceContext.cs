using Aniventi.DAL.ORM.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aniventi.DAL.ORM.Context
{
    public class AniventiECommerceContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS; Database=AniventiECommerceDb;Trusted_Connection=true;");
        }


        //public AniventiECommerceContext(DbContextOptions<AniventiECommerceContext> options) : base(options)
        //{

        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(20);


           // modelBuilder.Entity<Product>()
           //.HasOne<Category>(s => s.Category)
           //.WithMany(g => g.Products)
           //.HasForeignKey(s => s.CategoryId);


            // base.OnModelCreating(modelBuilder);


        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
