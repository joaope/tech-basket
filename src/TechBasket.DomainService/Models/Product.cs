namespace TechBasket.DomainService.Models
{
    public sealed class Product
    {
        public string Name{ get; }

        public ProductIdentifier Identifier { get; }

        public decimal Price { get; }

        public Product(string name, ProductIdentifier identifier, decimal price)
        {
            Name = name;
            Identifier = identifier;
            Price = price;
        }
    }
}