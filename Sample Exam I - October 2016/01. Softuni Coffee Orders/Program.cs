using System;
using System.Globalization;
//10:10
class Program
{
    static void Main()
    {
        int inputs = int.Parse(Console.ReadLine());
        decimal totalIncome = 0m;
        for (int i = 0; i < inputs; i++)
        {
            decimal priceFor1Capsule = decimal.Parse(Console.ReadLine());
            DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
            int countOfOrders = int.Parse(Console.ReadLine());
            int days = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
            decimal monthSales = days * priceFor1Capsule * countOfOrders;
            Console.WriteLine("The price for the coffee is: ${0:F2}", monthSales);
            totalIncome += monthSales;
        }
        Console.WriteLine("Total: ${0:F2}", totalIncome);
    }
}
//10:32