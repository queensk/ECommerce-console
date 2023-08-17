using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_console.Models;
using ECommerce_console.Helpers;

namespace ECommerce_console.Views
{
    public class ProductView
    {
        private string white = "\u001b[37m";
        private string blue = "\u001b[34m";
        private string green = "\u001b[32m";
        private string yellow = "\u001b[33m";
        private string magenta = "\u001b[35m";
        private string red = "\u001b[31m";
        private string resetColor = "\u001b[0m";
        private string lightBlue = "\u001b[36m";
        string orange = "\u001b[38;5;208m";

        public void ShowMenu(){
            Console.WriteLine("Sukuma Wiki ECommerce");
            Console.WriteLine($"{blue}1 - Create Product{resetColor}");
            Console.WriteLine($"{green}2 - List Products{resetColor}");
            Console.WriteLine($"{yellow}3 - product Details{resetColor}");
            Console.WriteLine($"{magenta}4 - Update Product{resetColor}");
            Console.WriteLine($"{lightBlue}5 - Delete Product{resetColor}");
            Console.WriteLine($"{red}6 - Exit{resetColor}");
        }

        public void clearView(){
            Console.Clear();
        }

        public string GetUserInputChoice(){
            return Console.ReadLine();
        }

        public void DisplayMessage(string message){
            Console.WriteLine($"{orange} {message} {resetColor}");
        }

        public Products GetProductsInput(){
            Console.WriteLine($"{green}Enter product Tittle {resetColor}");
            string? title  = Console.ReadLine();
            Console.WriteLine($"{lightBlue}Enter product Description {resetColor}");
            string? description = Console.ReadLine();
            Console.WriteLine($"{yellow}Enter product price {resetColor}");
            string? price = Console.ReadLine();
            Console.WriteLine($"{orange}Enter product category {resetColor}");
            string? category = Console.ReadLine();
            List<string> categories = new List<string>(){title, description, price, category};
            if(Validate.ValidateString(categories)){
                int priceInt = Int32.Parse(price);
                return new Products() { Title = title, Description = description, Price = priceInt, Category = category };
            }
            else{
                Console.WriteLine($"{red}Invalid input(s). Please enter valid input for all fields.{resetColor}");
                GetProductsInput();
                return null;
            }
        } 

        public string GetProductIdInput(){
            return Console.ReadLine();
        }

        public void DisplayProducts(List<Products>  products){
            Console.WriteLine($"{green}Products{resetColor}");
            Console.WriteLine($"{green}-------------------------------------------------------------------------------------{resetColor}");
            foreach (var product in products)
            {
                product.printProduct();
            }
        }
    }
}