using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionApi.Domain.Entities;

namespace OnionApi.Persistance.Configurations
{
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {

            Faker faker = new Faker("tr");

            Detail detail = new()
            {
                ID = 1,
                CategoryId = 3,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            Detail detail1 = new()
            {
                ID = 2,
                CategoryId = 4,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            Detail detail2 = new()
            {
                ID = 3,
                CategoryId = 3,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                CreatedDate = DateTime.Now,
                IsDeleted = true,
            };

            builder.HasData(detail1, detail, detail2);

        }
    }
}
