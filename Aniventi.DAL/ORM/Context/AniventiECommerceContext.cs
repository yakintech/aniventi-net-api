using Aniventi.DAL.ORM.Entity.Category;
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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS; Database=AniventiECommerceDb;Trusted_Connection=true");
        //}
        public DbSet<Category> Categories { get; set; }
    }
}
