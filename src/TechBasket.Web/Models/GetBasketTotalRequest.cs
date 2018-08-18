namespace TechBasket.Web.Models
{
    public sealed class GetBasketTotalRequest
    {
        private int[] _selectedProductsIdentifiers;

        public int[] SelectedProductsIdentifiers
        {
            get => _selectedProductsIdentifiers ?? new int[0];
            set => _selectedProductsIdentifiers = value;
        }
    }
}