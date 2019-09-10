using DotNetConf2019.GraphQL.Data;
using HotChocolate.Types;

namespace DotNetConf2019.GraphQL.Schema
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(a => a.Id)
               .Type<NonNullType<IdType>>();

            descriptor.Field(a => a.Name)
               .Type<NonNullType<StringType>>();
        }
    }
}
