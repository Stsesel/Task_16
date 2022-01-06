using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Task_16_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество товаров:\t");
            int productCount = int.Parse(Console.ReadLine());
            
            Product[] products = new Product[productCount];
            Console.WriteLine();


            for (int i = 0; i < productCount; i++)
            {
                Console.WriteLine("Введите код товара\t");
                int vendorCode = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите название товара\t");
                string productName = Console.ReadLine();

                Console.WriteLine("Введите цену товара\t");
                int productPrice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();


                products[i] = new Product() { VendorCode = vendorCode, ProductName = productName, ProductPrice = productPrice };
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(products, options);

            using (StreamWriter sw  =new StreamWriter("../../../Products.json"))
            {
                sw.WriteLine(jsonString);
            }
           
        }
    }
}
