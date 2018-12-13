using System;
using System.Linq;

class Program
{
    static void Main()
    {
        long health = long.Parse(Console.ReadLine());
        int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        char[][] jagMap = new char[size[0]][];

        for (int i = 0; i < jagMap.Length; i++)
        {
            char[] inputRow = Console.ReadLine().ToCharArray();
            jagMap[i] = inputRow;
        }

        int[] currentPosition = { -1, 0 };
        int[] exitPoint = jagMap[0].Length % 2 == 0 ? new int[2] { 0, jagMap[0].Length - 1 } : new int[2] { jagMap.Length - 1, jagMap[jagMap.Length - 1].Length - 1 };
        long turnsCounter = 0;

        while (health > 0 && !(currentPosition[0] == exitPoint[0] && currentPosition[1] == exitPoint[1]))
        {
            Move(jagMap, currentPosition);
            char currentAction = jagMap[currentPosition[0]][currentPosition[1]];
            if (currentAction == 'T')
            {
                turnsCounter += 2;
            }
            if (currentAction == 'F')
            {
                health -= turnsCounter / 2;
            }
            if (currentAction == 'H')
            {
                health += turnsCounter / 3;
            }
            turnsCounter++;
        }

        if (health <= 0)
        {
            Console.WriteLine($"Died at: [{string.Join(", ", currentPosition)}]");
        }
        else
        {
            Console.WriteLine($"Quest completed!\nHealth: {health}\nTurns: {turnsCounter}");
        }
    }

    static void Move(char[][] jag, int[] position)
    {
        int row = position[0];
        int col = position[1];
        if (col % 2 == 0)
        {
            if (row < jag.Length - 1)
            {
                position[0]++;
            }
            else if (col < jag[row].Length - 1)
            {
                position[1]++;
            }
        }
        else
        {
            if (row > 0)
            {
                position[0]--;
            }
            else if (col < jag[row].Length - 1)
            {
                position[1]++;
            }
        }
    }
}