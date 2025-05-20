namespace GraphQL.Models
{
    public record Order
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string UserId { get; set; }

        // Navigation properties
        public virtual  Product Product { get; set; }
        public virtual  User User { get; set; }

    }
}
