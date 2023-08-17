using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_console.Helpers
{
    public static class Validate
    {
        public static bool ValidateString(List<string> inputs)
        {
            foreach (var input in inputs)
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ValidateOptions(string? input, int start, int end)
        {
            if (int.TryParse(input, out int value) && value >= start && value <= end)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid option, please try again.");
                return false;
            }
        }
    }
}