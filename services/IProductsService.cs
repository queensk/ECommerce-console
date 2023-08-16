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

        Task<Products> GetProduct(int id);

        Task<StatusMessage> UpdateProduct(Products product);

        Task<StatusMessage> DeleteProduct(int id);

        Task<StatusMessage> AddProduct(Products product);
    }
}