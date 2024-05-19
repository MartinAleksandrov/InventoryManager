namespace InventoryManager_Services.Interfaces
{
    using InventoryManager_Data.ViewModels;
    using System.Threading.Tasks;

    public interface IProductService
    {
        Task<IEnumerable<AllProductsViewModel>> GetAllProductsAsync(string searchName, decimal? searchPrice);

        Task<bool> AddProductAsync(AddProductViewModel product);

        Task<ProductViewModel?> ExistByIdAsync(string id);

        Task<bool> EditProductAsync(ProductViewModel viewModel);

        Task<bool> DeleteProductAsync(string id);

        Task<List<WarehouseReportViewModel>> GetWarehouseReportAsync();

    }
}