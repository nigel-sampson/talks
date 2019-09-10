using HotChocolate.Types;

namespace DotNetConf2019.GraphQL.Schema
{
    public static class DescriptorExtensions
    {
        public static IObjectFieldDescriptor Type<TOutputType>(this IObjectFieldDescriptor descriptor, bool nullable) where TOutputType : class, IOutputType
        {
            return nullable ? descriptor.Type<TOutputType>() : descriptor.Type<NonNullType<TOutputType>>();
        }

        public static IObjectFieldDescriptor ListType<TOutputType>(this IObjectFieldDescriptor descriptor) where TOutputType : class, IOutputType
        {
            return descriptor.Type<NonNullType<ListType<NonNullType<TOutputType>>>>();
        }

        public static IArgumentDescriptor Type<TInputType>(this IArgumentDescriptor descriptor, bool nullable) where TInputType : class, IInputType
        {
            return nullable ? descriptor.Type<TInputType>() : descriptor.Type<NonNullType<TInputType>>();
        }
    }
}
