using System;
namespace _01._Hogswatch
{
    class Program
    {
        static void Main()
        {
            //9:45
            int homesCount = int.Parse(Console.ReadLine());
            int pressentsAmauntInicially = int.Parse(Console.ReadLine());
            int presentsCount = pressentsAmauntInicially;
            byte refills = 0;
            int pressentsTakenTotall = 0;
            for (int home = 1; home <= homesCount; home++)
            {
                int needOfPresentsForCurrentHome = int.Parse(Console.ReadLine());
                presentsCount -= needOfPresentsForCurrentHome;
                if (presentsCount < 0)
                {
                    int presentsTaken = (pressentsAmauntInicially / home) * (homesCount - home)-presentsCount;
                    refills++;
                    presentsCount = (pressentsAmauntInicially / home) * (homesCount - home);
                    pressentsTakenTotall += presentsTaken;
                }
            }
            if (refills != 0)
            {
                Console.WriteLine(refills);
                Console.WriteLine(pressentsTakenTotall);
            }
            else
            {
                Console.WriteLine(presentsCount);
            }
        }
    }
}
//10:15