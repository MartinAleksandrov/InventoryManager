namespace InventoryManager_Services
{
    using InventoryManager_Data;
    using InventoryManager_Data.Models;
    using InventoryManager_Data.ViewModels;
    using InventoryManager_Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly InventoryManagerDbContext dbContext;

        public ProductService(InventoryManagerDbContext context)
        {
            dbContext = context;
        }

        public async Task<bool> AddProductAsync(AddProductViewModel product)
        {
            var exist = await ExistByNameAsync(product.Name);

            if (exist)
            {
                return false;
            }

            var newProduct = new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Count = product.Count,
                Supplier = product.Supplier
            };

            dbContext.Products.Add(newProduct);
            await dbContext.SaveChangesAsync();

            return true;
        }

        private async Task<bool> ExistByNameAsync(string productName)
        {
            var product = await dbContext
                .Products
                .AnyAsync(p => p.Name == productName);

            if (product)
            {
                return true;
            }

            return false;
        }

        public async Task<ProductViewModel?> ExistByIdAsync(string id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id.ToString() == id);

            if (product == null)
            {
                return null;
            }

            var viewModel = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Count = product.Count,
                Supplier = product.Supplier
            };

            return viewModel;
        }

        public async Task<IEnumerable<AllProductsViewModel>> GetAllProductsAsync(string searchName, decimal? searchPrice)
        {
            var products = await dbContext
                .Products
                .AsNoTracking()
                .Select(p => new AllProductsViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Count = p.Count,
                    Supplier = p.Supplier
                })
                .ToListAsync();

            if (!string.IsNullOrEmpty(searchName))
            {
                products = products.Where(p => p.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (searchPrice.HasValue)
            {
                products = products.Where(p => p.Price == searchPrice.Value).ToList();
            }

            return products;
        }

        public async Task<bool> EditProductAsync(ProductViewModel viewModel)
        {
            var product = await dbContext.Products.FindAsync(viewModel.Id);

            if (product == null)
            {
                return false;
            }

            product.Name = viewModel.Name;
            product.Price = viewModel.Price;
            product.Count = viewModel.Count;
            product.Supplier = viewModel.Supplier;

            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            var product = await dbContext.Products.FindAsync(Guid.Parse(id));

            if (product == null)
            {
                return false;
            }

            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<WarehouseReportViewModel>> GetWarehouseReportAsync()
        {

            var report = await dbContext.Products.Select(p => new WarehouseReportViewModel
            {
                Name = p.Name,
                Count = p.Count,
                Value = Math.Round((p.Price * p.Count),2),
                Supplier = p.Supplier
            }).ToListAsync();

            return report;
        }
    }
}