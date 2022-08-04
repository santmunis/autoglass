using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Product;
using Infrastructure.Data.Mapping.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class DomainDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DomainDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ProductMapConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
