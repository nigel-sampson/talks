using HotChocolate;
using HotChocolate.Types;

namespace FullStackDays.Models
{
    public class OrderInput
    {
        public int Quantity { get; set; }

        [GraphQLType(typeof(NonNullType<IdType>))]
        public int ProductId { get; set; }
    }
}
