namespace Food.Products.Services.Entities
{

    public class Product : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string ImageUrl { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

    }
}