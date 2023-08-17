using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_console.Models;
using ECommerce_console.services;
using ECommerce_console.Views;

namespace ECommerce_console.controllers
{
    public class ProductController
    {
        private readonly IProductsService _productService;
        private readonly ProductView  _productView;

        public ProductController(IProductsService productService, ProductView productView)
        {
            _productService = productService;
            _productView = productView;
        }

        public async Task InitApplication()
        {
           bool running = true;
           while(running)
           {
            // _productView.clearView();
            _productView.ShowMenu();
            string choice = _productView.GetUserInputChoice();

            switch(choice)
            {
                case "1":
                    _productView.clearView();
                    await AddProduct();
                    break;
                case "2":
                    _productView.clearView();
                    await GetProducts();
                    break;
                case "3":
                    _productView.clearView();
                    await GetProductDetails();
                    break;
                case "4":
                    _productView.clearView();
                    await UpdateProduct();
                    break;
                case "5":
                    _productView.clearView();
                    await DeleteProduct();
                    break;
                case "6":
                    _productView.clearView();
                    _productView.DisplayMessage("Thank you for using our application");
                    running = false;
                    break;
                default:
                    _productView.DisplayMessage("Invalid choice");
                    break;
            }
           }
        }

        public async Task AddProduct()
        {
            _productView.DisplayMessage("Enter product Details:");
            Products newProduct = _productView.GetProductsInput();
            StatusMessage result = await _productService.AddProduct(newProduct);
        }
        
        public async Task GetProducts()
        {
            List<Products> products = await _productService.GetProducts();
            _productView.DisplayProducts(products);
        }

        public async Task GetProductDetails()
        {
            _productView.DisplayMessage("Enter Product id;");
            string id = _productView.GetUserInputChoice();
            Products product = await _productService.GetProduct(id);

            if (product != null)
            {
                product.printProduct();
            }else
            {
                _productView.DisplayMessage("Product Not Found");
            }
        }
        
        public async Task UpdateProduct()
        {
            _productView.DisplayMessage("Enter Product id;");
            string id = _productView.GetUserInputChoice();
            Products products = await _productService.GetProduct(id);
        
            if (products != null)
            {
                _productView.DisplayMessage("Enter new product details");
                Products newProduct = _productView.GetProductsInput();
                newProduct.Id = int.Parse(id);
                
                StatusMessage result = await _productService.UpdateProduct(newProduct);
                if (result != null)
                {
                    _productView.DisplayMessage($"Product With {id} is updated successfully");
                } else {
                    _productView.DisplayMessage("Failed to update product");
                }
            }else{
                _productView.DisplayMessage("Product Not Found");
            }
        }

        public async Task DeleteProduct()
        {
            _productView.DisplayMessage("Enter Product id;");
            string id = _productView.GetUserInputChoice();
            _productView.DisplayMessage("Are you sure you want to delete this product? (Y/N)");
            string choice = _productView.GetUserInputChoice();
            if (choice.ToLower() == "y")
            {
                StatusMessage result = await _productService.DeleteProduct(id);
                if (result != null)
                {
                    _productView.DisplayMessage($"Product With {id} is deleted successfully");
                } else {
                    _productView.DisplayMessage("Failed to delete product");
                }
            }
            else
            {
                _productView.ShowMenu();
            }
        }
    
    }
}