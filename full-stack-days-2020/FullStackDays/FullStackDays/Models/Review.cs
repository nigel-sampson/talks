using HotChocolate;
using HotChocolate.Types;

namespace FullStackDays.Models
{
    public class Review
    {
        public Review(int id, int productId, string author, string text)
        {
            Id = id;
            ProductId = productId;
            Author = author;
            Text = text;
        }

        [GraphQLType(typeof(NonNullType<IdType>))]
        public int Id { get; }

        [GraphQLIgnore]
        public int ProductId { get; }

        public string Author { get; }

        public string Text { get; }
    }
}
