using FullStackDays.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Linq;

namespace FullStackDays.Schema
{
    public class Query
    {
        public IReadOnlyCollection<Product> GetProducts() => MockData.Products;

        public Product? GetProduct([GraphQLType(typeof(NonNullType<IdType>))] int id) => MockData.Products.SingleOrDefault(p => p.Id == id);
    }
}
