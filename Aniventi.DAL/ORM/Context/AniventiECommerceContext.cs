using Aniventi.DAL.ORM.Entity.Category;
using Aniventi.DAL.ORM.Entity.Product;
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


        public AniventiECommerceContext(DbContextOptions<AniventiECommerceContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(20);

            base.OnModelCreating(modelBuilder);
                

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
