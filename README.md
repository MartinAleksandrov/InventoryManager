# InventoryManager

# InventoryManager Project Structure

```plaintext
InventoryManager/
│
├── Controllers/
│   ├── HomeController.cs
│   └── ProductController.cs
│
├── ModelBinders/
│   ├── DecimalModelBinder.cs
│   └── DecimalModelBinderProvider.cs
│
├── Views/
│   └── Product/
│       ├── AllProducts.cshtml
│       ├── CreateProduct.cshtml
│       ├── EditProduct.cshtml
│       ├── DeleteProduct.cshtml
│       └── WarehouseReport.cshtml
│
├── wwwroot/
│   ├── css/
│   │   ├── site.css
│   │   └── warehouse-report.css
│   └── js/
│       └── site.js
│
├── Program.cs
│
├── InventoryManager_Data/
│   ├── Migrations/
│   ├── Models/
│   │   └── Product.cs
│   ├── ViewModels/
│   │   ├── AllProductsViewModel.cs
│   │   ├── AddProductViewModel.cs
│   │   ├── WarehouseReportViewModel.cs
│   │   ├── ProductViewModel.cs
│   │   └── ErrorViewModel.cs
│   └── ApplicationDbContext.cs
│
├── InventoryManager_Services/
│   ├── Interfaces/
│   │   └── IProductService.cs
│   └── ProductService.cs
│
└── InventoryManager_Common/
    └── GlobalConstants/
        └── ProductConstants.cs


Features:
Product Management: Add, edit, and delete products.
Search and Filter: Search products by name or price.
Warehouse Report: Generate and view reports on the current state of the warehouse.
------------------------

Controllers
ProductController.cs
Index: Main landing page.
AllProducts: Displays all products with search functionality.
CreateProduct: GET and POST actions to create a new product.
EditProduct: GET and POST actions to edit an existing product.
DeleteProduct: GET action to confirm deletion and POST action to delete a product.
WarehouseReport: Generates and displays a report on the current state of the warehouse.
------------------------

ViewModels
AllProductsViewModel: Represents product data for displaying in lists.
AddProductViewModel: Represents data required for adding a new product.
WarehouseReportViewModel: Represents data for the warehouse report.
------------------------

Views
AllProducts.cshtml: Displays all products with search functionality.
CreateProduct.cshtml: Form for adding a new product.
EditProduct.cshtml: Form for editing an existing product.
DeleteProduct.cshtml: Confirmation page for deleting a product.
WarehouseReport.cshtml: Displays the warehouse report.
------------------------

Services
IProductService.cs
Interface defining methods for product management operations.
ProductService.cs
Implements IProductService with methods for adding, editing, deleting products, and generating warehouse reports.
