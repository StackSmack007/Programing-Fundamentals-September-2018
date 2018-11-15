using System;

//13:55
class Program
{
    static void Main()
    {
        int flights = int.Parse(Console.ReadLine());
        decimal OverallProfit = 0m;
        for (int i = 0; i < flights; i++)
        {
            int adultPassagers = int.Parse(Console.ReadLine());
            decimal adultTicketPrice = decimal.Parse(Console.ReadLine());
            int youthPassagers = int.Parse(Console.ReadLine());
            decimal youthTicketPrice = decimal.Parse(Console.ReadLine());
            decimal fuelPricePerHour = decimal.Parse(Console.ReadLine());
            decimal fuelConsumtionPerHour = decimal.Parse(Console.ReadLine());
            byte flightHours = byte.Parse(Console.ReadLine());
            decimal income = adultPassagers * adultTicketPrice + youthPassagers * youthTicketPrice;
            decimal expences = flightHours * fuelPricePerHour * fuelConsumtionPerHour;
            if (income >= expences)
            {
                Console.WriteLine("You are ahead with {0:F3}$.", income - expences);
            }
            else
            {
                Console.WriteLine("We've got to sell more tickets! We've lost {0:F3}$.", income - expences);
            }
            OverallProfit += income - expences;
        }
        Console.WriteLine("Overall profit -> {0:F3}$.",OverallProfit);
        Console.WriteLine("Average profit -> {0:F3}$.",OverallProfit/flights);
            }
}
//14:35