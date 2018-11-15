using System;
using System.Linq;
//11:40

class Program
{
    static void Main()
    {
        long[] arrayOfNumbers = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
        while (true)
        {
            string[] commandArray = Console.ReadLine().Split(' ');
            if (commandArray[0]=="end")
            {
                break;
            }
            if (commandArray[0]=="swap")
            {
                int index1st = int.Parse(commandArray[1]);
                int index2nd = int.Parse(commandArray[2]);
                long temporary = arrayOfNumbers[index1st];
                arrayOfNumbers[index1st] = arrayOfNumbers[index2nd];
                arrayOfNumbers[index2nd] = temporary;
            }
            else if (commandArray[0] == "multiply")
            {
                int index1st = int.Parse(commandArray[1]);
                int index2nd = int.Parse(commandArray[2]);
                arrayOfNumbers[index1st] *= arrayOfNumbers[index2nd];
            }
            else if (commandArray[0]=="decrease")
            {
                for (int i = 0; i < arrayOfNumbers.Length; i++)
                {
                    arrayOfNumbers[i] -= 1;
                }
            }
        }
        Console.WriteLine(string.Join(", ",arrayOfNumbers));
    }
}
//12:05