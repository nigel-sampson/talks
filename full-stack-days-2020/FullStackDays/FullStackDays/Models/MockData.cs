using Bogus;
using System;
using System.Collections.Generic;

namespace FullStackDays.Models
{
    public static class MockData
    {
        static MockData()
        {
            Randomizer.Seed = new Random(13);

            var productIds = 1;
            var reviewIds = 1;

            Products = new Faker<Product>()
                .CustomInstantiator(f => new Product(productIds++, f.Commerce.Product(), f.Finance.Amount()))
                .Generate(32);

            Reviews = new Faker<Review>()
                .CustomInstantiator(f =>
                {
                    var product = f.PickRandom<Product>(Products);
                    return new Review(reviewIds++, product.Id, f.Name.FullName(), f.Rant.Review(product.Name));
                })
                .Generate(64);

            Images = new Faker<Image>()
               .CustomInstantiator(f =>
               {
                   var product = f.PickRandom<Product>(Products);
                   return new Image(product.Id, f.Random.Enum<ImageSize>(), f.Image.LoremPixelUrl());
               })
               .Generate(64);
        }

        public static IReadOnlyCollection<Product> Products { get; private set; }

        public static IReadOnlyCollection<Review> Reviews { get; private set; }

        public static IReadOnlyCollection<Image> Images { get; private set; }
    }
}
