using System;
using System.Collections.Generic;
using System.Globalization;
class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        Queue<decimal> proffits = new Queue<decimal>(N);
        for (int i = 0; i < N; i++)
        {
            decimal price = decimal.Parse(Console.ReadLine());
            DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
            int daysInThisMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
            uint ordersPerDay = uint.Parse(Console.ReadLine());
            proffits.Enqueue(ordersPerDay * daysInThisMonth * price);
        }
        decimal totalProffit = 0;
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine("The price for the coffee is: ${0:F2}", proffits.Peek());
            totalProffit += proffits.Dequeue();
        }
        Console.WriteLine("Total: ${0:F2}", totalProffit);
    }
}