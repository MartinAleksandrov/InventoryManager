namespace InventoryManager_Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static InventoryManager_Common.ProductConstants;
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(ProductPriceMaxLength)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(SupplierNameMaxLength)]
        public string Supplier { get; set; } = string.Empty;

        public int Count { get; set; }
    }
}