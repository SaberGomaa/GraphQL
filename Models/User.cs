namespace GraphQL.Models
{
    public record User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

    }
}
