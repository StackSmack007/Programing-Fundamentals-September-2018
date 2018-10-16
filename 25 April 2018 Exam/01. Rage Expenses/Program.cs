using System;
//10:10
class Program
{
    static void Main()
    {
        ushort lostGames = ushort.Parse(Console.ReadLine());//7
        decimal headsetPrice = decimal.Parse(Console.ReadLine());
        decimal mousePrice = decimal.Parse(Console.ReadLine());
        decimal keyboardPrice = decimal.Parse(Console.ReadLine());
        ushort keyboardsDestroyed = 0;
        decimal displayPrice = decimal.Parse(Console.ReadLine());
        decimal expenses = 0;
        for (int i = 1; i <= lostGames; i++)
        {
            if (i % 2 == 0)
            {
                expenses += headsetPrice;
            }
            if (i % 3 == 0)
            {
                expenses += mousePrice;
            }
            if (i % 2 == 0 & i % 3 == 0)
            {
                expenses += keyboardPrice;
                keyboardsDestroyed++;
                if (keyboardsDestroyed % 2 == 0)
                {
                    expenses += displayPrice;
                }
            }
        }
        Console.WriteLine("Rage expenses: {0:F2} lv.",expenses);
    }
}
//10:28