namespace InventoryManager_Data.ViewModels
{
    public class WarehouseReportViewModel
    {
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
        public decimal Value { get; set; }
        public string Supplier { get; set; } = string.Empty;
    }
}