using System;
//16:40
//16:50
class Program
{
    static void Main()
    {
        decimal budjet = decimal.Parse(Console.ReadLine());
        int guests = int.Parse(Console.ReadLine());
        decimal bananasFor1portionPrice = 2 * decimal.Parse(Console.ReadLine());
        decimal eggsFor1portionPrice = 4 * decimal.Parse(Console.ReadLine());
        decimal berriesFor1portionPrice = 0.2m * decimal.Parse(Console.ReadLine());
        decimal priceFor1portion = bananasFor1portionPrice + eggsFor1portionPrice + berriesFor1portionPrice;
        int portions = (int)Math.Ceiling(guests / 6.0);
        decimal moneyNeeded = portions * priceFor1portion;
        if (budjet >= moneyNeeded)
        {
            Console.WriteLine("Ivancho has enough money - it would cost {0:F2}lv.", moneyNeeded);
        }
        else
        {
            Console.WriteLine("Ivancho will have to withdraw money - he will need {0:F2}lv more.", moneyNeeded - budjet);
        }
    }
}
//17:05