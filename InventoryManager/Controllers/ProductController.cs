namespace InventoryManager.Controllers
{
    using InventoryManager_Data.ViewModels;
    using InventoryManager_Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService service)
        {
            productService = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AllProducts(string searchName, decimal? searchPrice)
        {
            var allProducts = await productService.GetAllProductsAsync(searchName,searchPrice);
           
            return View(allProducts);
        }

        [HttpGet]
        public async Task<IActionResult> WarehouseReport()
        {
            var report = await productService.GetWarehouseReportAsync();
            return View(report);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(AddProductViewModel viewModel)
        {
            try
            {
                var create = await productService.AddProductAsync(viewModel);

                if (create)
                {
                    return RedirectToAction(nameof(AllProducts));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(viewModel.Name, "Unexpected error occurred, please try again later or contact an administrator");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(string id)
        {
            var product = await productService.ExistByIdAsync(id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(string id, ProductViewModel viewModel)
        {
            try
            {
                var product = await productService.EditProductAsync(viewModel);

                if (product)
                {
                    return RedirectToAction(nameof(AllProducts));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(viewModel.Name, "Unexpected error occurred, please try again later or contact an administrator");
            }

            return RedirectToAction(nameof(AllProducts));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var product = await productService.ExistByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var deleteProduct = await productService.DeleteProductAsync(id);

            if (!deleteProduct)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(AllProducts));
        }
    }
}
