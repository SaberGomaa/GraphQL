
using GraphQL.Data;
using GraphQL.GraphQL.Mutations;
using GraphQL.GraphQL.Types;
using GraphQL.Queries;
using Microsoft.EntityFrameworkCore;
namespace GraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddDbContextFactory<graphQLDbContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("TBFConnectionString")));

            // Add GraphQL services (using HotChocolate)
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<UserType>()
                .AddType<ProductType>()
                .AddType<OrderType>()
                .AddFiltering()
                .AddSorting()
                .AddProjections()
                .AddErrorFilter(error =>
                {
                    if (error.Exception != null)
                    {
                        return error.WithMessage(error.Exception.Message);
                    }
                    return error;
                });

            builder.Services.AddControllers();
            // Configure Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.MapGraphQL();

            app.Run();
        }
    }
}