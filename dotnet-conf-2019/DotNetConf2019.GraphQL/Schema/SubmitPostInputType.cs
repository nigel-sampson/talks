using HotChocolate.Types;

namespace DotNetConf2019.GraphQL.Schema
{
    public class SubmitPostInputType : InputObjectType<SubmitPostInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<SubmitPostInput> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(i => i.AuthorId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(i => i.Title)
                .Type<NonNullType<StringType>>();

        }
    }
}
