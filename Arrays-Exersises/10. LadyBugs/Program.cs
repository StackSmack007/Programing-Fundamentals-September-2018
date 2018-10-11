using System;
using System.Linq;
class Program
{
    static void Main()
    {
        int[] field = new int[int.Parse(Console.ReadLine())];
        int[] ladybugIndexes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        for (int i = 0; i < field.Length; i++)
        {
            if (ladybugIndexes.Contains(i))
            {
                field[i] = 1;
            }
            else
            {
                field[i] = 0;
            }
        }
        while (true)
        {
            string[] command = Console.ReadLine().Split(new char[] { ' ' });
            if (command[0] == "end")
            {
                Console.WriteLine(string.Join(" ", field));
                return;
            }
            string destination = command[1];
            int startIndex = int.Parse(command[0]);
            int distance = int.Parse(command[2]);
            int endIndex = startIndex + (destination == "right" ? distance : -distance);
            if (startIndex < 0 || startIndex > field.Length - 1)
            {
                continue;
            }
            else if (field[startIndex] == 0)
            {
                continue;
            }
            field[startIndex] = 0;//we have a liftOff!
            while (endIndex >= 0 & endIndex < field.Length)//findSpaceForLanding
            {
                if (field[endIndex] == 1)
                {
                    if (destination == "right")
                    {
                        endIndex += distance;
                    }
                    else
                    {
                        endIndex -= distance;
                    }
                }
                else
                {
                    field[endIndex] = 1;
                    break;
                }
            }
        }
    }
}