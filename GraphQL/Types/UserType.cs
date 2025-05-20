using GraphQL.GraphQL.Types;
using GraphQL.Models;

public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.Field(u => u.Name).Type<NonNullType<StringType>>();
        descriptor.Field(u => u.Password).Type<NonNullType<StringType>>(); // Note: Consider hiding in production
    }
}
