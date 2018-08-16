namespace TechBasket.DomainService.Models
{
    public sealed class PricedProduct
    {
        public ProductIdentifier Identifier { get; }

        public decimal InitialPrice { get; }

        public decimal DiscountedPrice { get; private set; }

        public PricedProduct(ProductIdentifier identifier, decimal initialPrice)
        {
            Identifier = identifier;
            InitialPrice = DiscountedPrice = initialPrice;
        }

        public void SetDiscountedPrice(decimal discountedPrice)
        {
            DiscountedPrice = discountedPrice;
        }
    }
}
