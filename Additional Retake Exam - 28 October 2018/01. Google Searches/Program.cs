using System;

    class Program
    {
        static void Main()
        {
        int totalDays = int.Parse(Console.ReadLine());
        int usersNumber=int.Parse(Console.ReadLine());
        decimal moneyPerSearsch = decimal.Parse(Console.ReadLine());
        decimal proffit = 0m;
        for (int i = 1; i <= usersNumber; i++)
        {
            int wordsFromUser = int.Parse(Console.ReadLine());
            int value = 1;
            if (wordsFromUser > 5)
            {
                value=0;
            }
            else if (wordsFromUser == 1)
            {
                value = 2;
            }
            if (i%3==0)
            {
                value *= 3;
            }
            proffit +=  value;
        }
        proffit *= moneyPerSearsch*totalDays;
        Console.WriteLine("Total money earned for {0} days: {1:F2}",totalDays,proffit);
        }
    }
