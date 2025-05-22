
using GraphQL.Data;
using GraphQL.GraphQL.Inputs;
using GraphQL.Models;
using Microsoft.EntityFrameworkCore;
namespace GraphQL.GraphQL.Mutations
{
    public class Mutation
    {
        [UseDbContext(typeof(graphQLDbContext))]
        public async Task<User> AddUserAsync(AddUserInput input, [Service] graphQLDbContext context)
        {
            var user = new User
            {
                UserId = input.UserId,
                Name = input.Name,
                Password = input.Password // Note: In production, hash the password
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        [UseDbContext(typeof(graphQLDbContext))]
        public async Task<User> UpdateUserAsync(UpdateUserInput input, [Service] graphQLDbContext context)
        {
            var user = await context.Users.FindAsync(input.UserId)
                ?? throw new Exception($"User with ID {input.UserId} not found");

            user.Name = input.Name;
            user.Password = input.Password; // Note: In production, hash the password
            await context.SaveChangesAsync();
            return user;
        }

        [UseDbContext(typeof(graphQLDbContext))]
        public async Task<Product> AddProductAsync(AddProductInput input, [Service] graphQLDbContext context)
        {
            var product = new Product
            {
                ProductId = input.ProductId,
                Name = input.Name,
                Price = input.Price,
                isAvilable = input.isAvilable,
                Type = input.Type
            };
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return product;
        }

        [UseDbContext(typeof(graphQLDbContext))]
        public async Task<Product> UpdateProductAsync(UpdateProductInput input, [Service] graphQLDbContext context)
        {
            var product = await context.Products.FindAsync(input.ProductId)
                ?? throw new Exception($"Product with ID {input.ProductId} not found");

            product.Name = input.Name;
            await context.SaveChangesAsync();
            return product;
        }

        [UseDbContext(typeof(graphQLDbContext))]
        public async Task<Order> AddOrderAsync(AddOrderInput input, [Service] graphQLDbContext context)
        {
            // Validate UserId and ProductId exist
            if (!await context.Users.AnyAsync(u => u.UserId == input.UserId))
                throw new Exception($"User with ID {input.UserId} not found");
            if (!await context.Products.AnyAsync(p => p.ProductId == input.ProductId))
                throw new Exception($"Product with ID {input.ProductId} not found");

            var order = new Order
            {
                OrderId = input.OrderId,
                UserId = input.UserId,
                ProductId = input.ProductId
            };
            context.Orders.Add(order);
            await context.SaveChangesAsync();
            return order;
        }

        [UseDbContext(typeof(graphQLDbContext))]
        public async Task<Order> UpdateOrderAsync(UpdateOrderInput input, [Service] graphQLDbContext context)
        {
            var order = await context.Orders.FindAsync(input.OrderId)
                ?? throw new Exception($"Order with ID {input.OrderId} not found");

            // Validate UserId and ProductId exist
            if (!await context.Users.AnyAsync(u => u.UserId == input.UserId))
                throw new Exception($"User with ID {input.UserId} not found");
            if (!await context.Products.AnyAsync(p => p.ProductId == input.ProductId))
                throw new Exception($"Product with ID {input.ProductId} not found");

            order.UserId = input.UserId;
            order.ProductId = input.ProductId;
            await context.SaveChangesAsync();
            return order;
        }
    }
}