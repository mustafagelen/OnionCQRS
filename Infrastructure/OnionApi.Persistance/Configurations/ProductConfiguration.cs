using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Persistance.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker = new Faker("tr");

         
            Product product1 = new Product()
            {
                ID = 1,
                Description = faker.Commerce.ProductDescription(),
                Title = faker.Commerce.ProductName(),
                BrandId = 1,
                Discount = faker.Random.Decimal(1, 123),
                Price = faker.Finance.Amount(10, 100),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            Product product2 = new Product()
            {
                ID = 2,
                Description = faker.Commerce.ProductDescription(),
                Title = faker.Commerce.ProductName(),
                BrandId = 3,
                Discount = faker.Random.Decimal(1, 123),
                Price = faker.Finance.Amount(10, 100),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };

            builder.HasData(product1, product2);

        }
    }
}
