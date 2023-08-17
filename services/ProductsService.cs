using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_console.Models;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;

namespace ECommerce_console.services
{
    public class ProductsService : IProductsService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public ProductsService()
        {
            _httpClient.BaseAddress = new Uri("http://localhost:3000/");
        }
        public async Task <StatusMessage> AddProduct(Products product)
        {
            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("products", content);
            if (response.IsSuccessStatusCode)
            {
                return new StatusMessage { message = "Product added successfully" };
            }
            else
            {
                throw new Exception("Failed to add Product.");
            }
        }

        public async Task <StatusMessage> DeleteProduct(string id)
        {
            var response = await _httpClient.DeleteAsync($"products/{id}");
            if (response.IsSuccessStatusCode)
            {
                return new StatusMessage { message = "Product deleted successfully" };
            }
            else
            {
                throw new Exception("Failed to delete Product.");
            }
        
        }

        public async Task <Products> GetProduct(string id)
        {
            var response = await _httpClient.GetAsync($"products/{id}");
            if (response.IsSuccessStatusCode)
            {
                var product = JsonSerializer.Deserialize<Products>(await response.Content.ReadAsStringAsync());
                return product ?? new Products();
            }
            else
            {
                throw new Exception("Failed to get Product.");
            }
        }

        public async Task <List<Products>> GetProducts()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Products>>("products");
            return response ?? new List<Products>();
        }

        public async Task <StatusMessage> UpdateProduct(Products product)
        {
            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"products/{product.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                 return new StatusMessage { message = "Book updated successfully" };
            }
            else
            {
                return new StatusMessage { message = "Failed to update book." };
            }
        }
    }
}
