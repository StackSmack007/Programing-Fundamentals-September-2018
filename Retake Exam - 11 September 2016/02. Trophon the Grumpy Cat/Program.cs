using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] items = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int positionIndex = int.Parse(Console.ReadLine());
        string priceRange = Console.ReadLine();
        string typeOfValues = Console.ReadLine();

        long sumLeft = 0;
        long sumRight = 0;
        for (int i = 0; i < items.Length; i++)
        {
            if (i < positionIndex)
            {
                if (IsValidPrice(items[positionIndex], items[i], priceRange))
                {
                    sumLeft += IsValidType(items[i], typeOfValues);
                }
            }
            else if (i> positionIndex)
            {
                if (IsValidPrice(items[positionIndex], items[i], priceRange))
                {
                    sumRight += IsValidType(items[i], typeOfValues);
                }
            }
        }
        if (sumLeft >= sumRight)
        {
            Console.WriteLine("Left - " + sumLeft);
        }
        else
        {
            Console.WriteLine("Right - " + sumRight);
        }
    }
    static bool IsValidPrice(int baseValue, int value, string priceRange)
    {
        if (priceRange == "cheap" & value < baseValue)
        {
            return true;
        }
        else if (priceRange == "expensive" & value >= baseValue)
        {
            return true;
        }
        return false;
    }

    static int IsValidType(int value, string type)
    {
        if (type == "positive")
        {
            if (value > 0)
            {
                return value;
            }
        }
        else if (type == "negative")
        {
            if (value < 0)
            {
                return value;
            }
        }
        else if (type == "all")
        {
            return value;
        }
        return 0;
    }
}