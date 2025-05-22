namespace GraphQL.Models
{
    public record Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool isAvilable { get; set; }
        public string Type { get; set; }

    }
}
