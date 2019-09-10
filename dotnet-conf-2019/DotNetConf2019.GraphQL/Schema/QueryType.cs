using HotChocolate.Types;

namespace DotNetConf2019.GraphQL.Schema
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(q => q.GetPosts(default))
                .Type<NonNullType<ListType<NonNullType<PostType>>>>();

            descriptor.Field(q => q.GetPost(default, default))
               .Argument("id", a => a.Type<NonNullType<IdType>>());
        }
    }
}
