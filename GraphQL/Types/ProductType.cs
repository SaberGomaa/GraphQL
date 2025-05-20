
using GraphQL.Models;

namespace GraphQL.GraphQL.Types
{
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor.Field(p => p.ProductId).Type<NonNullType>();
            descriptor.Field(p => p.Name).Type<NonNullType>();
            descriptor.Field(p => p.Price).Type<NonNullType>();
            descriptor.Field(p => p.Orders).Type<ListType>();
        }
    }
}