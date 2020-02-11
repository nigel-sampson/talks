using HotChocolate;

namespace FullStackDays.Models
{
    public class Image
    {
        public Image(int productId, ImageSize size, string url)
        {
            ProductId = productId;
            Size = size;
            Url = url;
        }

        [GraphQLIgnore]
        public int ProductId { get; }

        public ImageSize Size { get; }

        public string Url { get; }
    }
}
