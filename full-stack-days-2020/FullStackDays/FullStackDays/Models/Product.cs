using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Linq;

namespace FullStackDays.Models
{
    public class Product
    {
        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        [GraphQLType(typeof(NonNullType<IdType>))]
        public int Id { get; }

        public string Name { get; }

        public decimal Price { get; set; }

        public IReadOnlyCollection<Review> GetReviews() => MockData.Reviews.Where(r => r.ProductId == Id).ToList();

        public Image? GetImage(ImageSize size) => MockData.Images.FirstOrDefault(i => i.ProductId == Id && i.Size == size);

        [GraphQLDeprecated("Use image(size: THUMBNAIL) instead")]
        public Image? Thumbnail => MockData.Images.FirstOrDefault(i => i.ProductId == Id && i.Size == ImageSize.Thumbnail);
    }
}
