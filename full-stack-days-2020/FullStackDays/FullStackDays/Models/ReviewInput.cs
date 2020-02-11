using HotChocolate;
using HotChocolate.Types;

namespace FullStackDays.Models
{
    public class ReviewInput
    {
        public string? Text { get; set; }

        [GraphQLType(typeof(NonNullType<IdType>))]
        public int ProductId { get; set; }
    }
}
