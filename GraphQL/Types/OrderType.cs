using GraphQL.Models;

namespace GraphQL.GraphQL.Types
{
    public class OrderType : ObjectType<Order>
    {
        protected override void Configure(IObjectTypeDescriptor<Order> descriptor)
        {
            descriptor.Field(o => o.OrderId).Type<NonNullType<IdType>>();
            descriptor.Field(o => o.UserId).Type<NonNullType<IdType>>();
            descriptor.Field(o => o.ProductId).Type<NonNullType<IdType>>();
        }
    }

}
