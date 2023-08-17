using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_console.Models;

namespace ECommerce_console.services
{
    public interface IProductsService
    {
        Task<List<Products>> GetProducts();

        Task<Products> GetProduct(string id);

        Task<StatusMessage> UpdateProduct(Products product);

        Task<StatusMessage> DeleteProduct(string id);

        Task<StatusMessage> AddProduct(Products product);
    }
}