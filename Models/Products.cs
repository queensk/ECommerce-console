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

        public override string ToString()
        {
            return$"Id: {Id} Title: {Title} Description: {Description} Category: {Category} Price: {Price}";
        }

        public void printProduct()
        {
        Console.WriteLine($"{ConsoleColor.White}Id: {ConsoleColor.Blue}{Id} {ConsoleColor.White}Title: {ConsoleColor.Green}{Title} {ConsoleColor.White}Description: {ConsoleColor.Yellow}{Description} {ConsoleColor.White}Category: {ConsoleColor.Magenta}{Category} {ConsoleColor.White}Price: {ConsoleColor.Red}{Price}");

        Console.ResetColor();
        }

    }

}