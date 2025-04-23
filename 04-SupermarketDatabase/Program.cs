using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SupermarketDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            var dict = new Dictionary<string, Dictionary<double, double>>();

            while (input[0] != "stocked")
            {
                string productName = input[0];
                double price = double.Parse(input[1]);
                double quantity =double.Parse(input[2]);

                if (!dict.ContainsKey(productName))
                {
                    dict[productName] = new Dictionary<double, double>();
                    
                }
                 if (!dict[productName].ContainsKey(price))
                {
                    dict[productName][price] = 0;
                }
                dict[productName][price] += quantity;
                input = Console.ReadLine().Split().ToArray();
            }
            double totalSum = 0;
            foreach (var item in dict)
            {
                
                string product = item.Key;
                double finalPrice = item.Value.Keys.Last();
                double allQuantity = item.Value.Values.Sum();
                double allPrice = finalPrice * allQuantity;

                totalSum += allPrice;
               
                Console.WriteLine("{0}: ${1:F2} * {2:F0} = ${3:F2}",
                    product, finalPrice,allQuantity,allPrice);
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine("Grand Total: ${0:F2}",totalSum);
        }
    }
}
