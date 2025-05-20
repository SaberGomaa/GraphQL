using GraphQL.Data;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Queries
{
    public class Query
    {
        [UseDbContext(typeof(graphQLDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([Service] graphQLDbContext context)
        {
            return context.Users;
        }

        [UseDbContext(typeof(graphQLDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Product> GetProducts([Service] graphQLDbContext context)
        {
            return context.Products;
        }

        [UseDbContext(typeof(graphQLDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Order> GetOrders([Service] graphQLDbContext context)
        {
            return context.Orders.Include(o => o.User).Include(o => o.Product);
        }

        [UseDbContext(typeof(graphQLDbContext))]
        public async Task<User> GetUserByIdAsync(string userId, [Service] graphQLDbContext context)
        {
            return await context.Users
                                .FirstOrDefaultAsync(u => u.UserId == userId)
                ?? throw new Exception($"User with ID {userId} not found");
        }

        [UseDbContext(typeof(graphQLDbContext))]
        public async Task<Product> GetProductByIdAsync(string productId, [Service] graphQLDbContext context)
        {
            return await context.Products   
                .FirstOrDefaultAsync(p => p.ProductId == productId)
                ?? throw new Exception($"Product with ID {productId} not found");
        }

        [UseDbContext(typeof(graphQLDbContext))]
        public async Task<Order> GetOrderByIdAsync(string orderId, [Service] graphQLDbContext context)
        {
            return await context.Orders
                .Include(o => o.User)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(o => o.OrderId == orderId)
                ?? throw new Exception($"Order with ID {orderId} not found");
        }
    }
}