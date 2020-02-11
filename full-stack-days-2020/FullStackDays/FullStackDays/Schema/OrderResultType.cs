using FullStackDays.Models;
using HotChocolate.Types;

namespace FullStackDays.Schema
{
    public class OrderResultType : UnionType<OrderResult>
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor
                .Type<ObjectType<OrderCompletedResult>>()
                .Type< ObjectType<InsufficientQuantityResult>>()
                .Type< ObjectType<InvalidOrderResult>>();
        }
    }
}
