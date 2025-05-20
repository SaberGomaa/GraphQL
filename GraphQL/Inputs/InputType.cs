namespace GraphQL.GraphQL.Inputs
{
    public record AddUserInput(string UserId, string Name, string Password);
    public record UpdateUserInput(string UserId, string Name, string Password);
    public record AddProductInput(string ProductId, string Name, decimal Price);
    public record UpdateProductInput(string ProductId, string Name, decimal Price);
    public record AddOrderInput(string OrderId, string UserId, string ProductId);
    public record UpdateOrderInput(string OrderId, string UserId, string ProductId);

}