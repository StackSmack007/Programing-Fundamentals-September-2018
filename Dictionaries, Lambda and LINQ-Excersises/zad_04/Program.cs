using System;
using System.Collections.Generic;
using System.Linq;
namespace zad_04
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            Dictionary<string, double[]> itemPriceQuantity = new Dictionary<string, double[]>();
            while (input[0] != "stocked")
            {
                string item = input[0];
                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);
                if (!itemPriceQuantity.ContainsKey(item))
                {
                    itemPriceQuantity[item] = new double[2];
                    itemPriceQuantity[item][0] = price;
                    itemPriceQuantity[item][1] = quantity;
                }
                else
                {
                    itemPriceQuantity[item][0] = price;
                    itemPriceQuantity[item][1] += quantity;
                }
                input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            double totalCost = 0.0;
            foreach (var kvp in itemPriceQuantity)
            {
                double localCost = kvp.Value[0] * kvp.Value[1];
                totalCost += localCost;
                Console.WriteLine("{0}: ${1:F2} * {2:F0} = ${3:F2}",kvp.Key, kvp.Value[0], kvp.Value[1], localCost);
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Grand Total: ${ totalCost:F2}");
        }
    }
}
