using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_console.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public int Price { get; set; }

        public Products(int id, string title, string description, string category, int price)
        {
            Id = id;
            Title = title;
            Description = description;
            Category = category;
            Price = price;
        }

        public void printProduct()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return$"Id: {Id} Title: {Title} Description: {Description} Category: {Category} Price: {Price}";
        }
    }

}