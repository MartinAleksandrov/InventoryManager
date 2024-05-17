namespace InventoryManager_Data.ViewModels
{
    public class AllProductsViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Supplier { get; set; } = string.Empty;

        public int Count { get; set; }
    }
}