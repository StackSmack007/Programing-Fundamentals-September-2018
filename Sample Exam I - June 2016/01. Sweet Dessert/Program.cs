using System;
//11:30

class Program
{
    static void Main()
    {
        var budget = decimal.Parse(Console.ReadLine());
        var guests = int.Parse(Console.ReadLine());
        var priceOf1Bannana = decimal.Parse(Console.ReadLine());
        var priceOf1Egg = decimal.Parse(Console.ReadLine());
        var priceOf1kgBerries = decimal.Parse(Console.ReadLine());
        decimal portionPrice = 2 * priceOf1Bannana + 4 * priceOf1Egg + 0.2m * priceOf1kgBerries;
        int numberOfPortions = (int)Math.Ceiling(guests / 6.0);
        decimal totalCost = numberOfPortions * portionPrice;
        if (budget >= totalCost)
        {
            Console.WriteLine("Ivancho has enough money - it would cost {0:F2}lv.", totalCost);
        }
        else
        {
            Console.WriteLine("Ivancho will have to withdraw money - he will need {0:F2}lv more.", totalCost - budget);
        }
    }
}
//11:40