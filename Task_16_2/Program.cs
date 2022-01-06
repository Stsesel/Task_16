using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Task_16_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);


            Product maxProduct = products[0];
            foreach (Product item in products)
            {
                if (item.ProductPrice > maxProduct.ProductPrice)
                {
                    maxProduct = item;
                } 
            }
            Console.WriteLine($"{maxProduct.VendorCode} {maxProduct.ProductName} {maxProduct.ProductPrice}");
            Console.ReadKey();
        }
    }
}
