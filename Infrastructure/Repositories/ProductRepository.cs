using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Product;
using Domain.Interfaces;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public sealed override DbSet<Product> Collection { get; set; }
        public ProductRepository(DomainDbContext context) : base(context)
        {
            Collection = context.Products;
        }

        
    }
}
