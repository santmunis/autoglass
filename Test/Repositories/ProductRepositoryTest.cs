using System;
using System.Threading.Tasks;
using Domain.Product;
using Infrastructure.Data.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Test.Repositories
{
    public class ProductRepositoryTest
    {
        [Fact]
        public void GetById()
        {
            var options = new DbContextOptionsBuilder<DomainDbContext>()
                .UseInMemoryDatabase(databaseName: "autoglass")
                .Options;

            using (var context = new DomainDbContext(options))
            {
                context.Products.Add(Product.Create("sadasd", false, DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 3, "dasdas", "dsadasdsa"));
                context.SaveChanges();
            }

            using (var context = new DomainDbContext(options))
            {
                var sut = new ProductRepository(context);
              
                var product = sut.GetById(1).Result;

                Assert.NotNull(product);
                Assert.IsAssignableFrom<Product>(product);
            }

        }
    }
}
