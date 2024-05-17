namespace InventoryManager_Data.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using static InventoryManager_Common.GlobalConstants.ProductConstants;
    public class AddProductViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(ProductNameMaxLength,MinimumLength =ProductNameMinLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(ProductPriceMinLength,ProductPriceMaxLength)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(SupplierNameMaxLength, MinimumLength = SupplierNameMinLength)]
        public string Supplier { get; set; } = string.Empty;

        [Required]
        public int Count { get; set; }
    }
}