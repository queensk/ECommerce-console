using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_console.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Title { get; set; }= string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public int Price { get; set; }

        public override string ToString()
        {
            return$"Id: {Id} Title: {Title} Description: {Description} Category: {Category} Price: {Price}";
        }

        public void printProduct()
        {
            string white = "\u001b[37m";
            string blue = "\u001b[34m";
            string green = "\u001b[32m";
            string yellow = "\u001b[33m";
            string magenta = "\u001b[35m";
            string red = "\u001b[31m";
            string orange = "\u001b[38;5;208m";
            string resetColor = "\u001b[0m";

            string output = $"{white}Id: {blue}{Id}\n{white}Title: {green}{Title}\n{white}Description: {yellow}{Description}\n{white}Category: {magenta}{Category}\n{white}Price: {red}{Price}\n{orange}-------------------------------------------------------------------------------------{resetColor}";

            Console.WriteLine(output);
        }
    }
}
