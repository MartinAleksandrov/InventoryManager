namespace InventoryManager_Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class ProductManager
    {
        public ProductManager()
        {
            Products = new List<Product>();
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public IEnumerable<Product> Products { get; set; }

    }
}