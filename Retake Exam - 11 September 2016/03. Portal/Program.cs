using System;

class Program
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        char[][] room = new char[rows][];
        for (int i = 0; i < rows; i++)
        {
            char[] input = Console.ReadLine().ToUpper().ToCharArray();
            room[i] = input;
        }
        string command = Console.ReadLine();
        for (int i = 0; i < command.Length; i++)
        {
            Move(room, command[i]);
            if (Location(room, 'S')[0] == -1)
            {
                Console.WriteLine("Experiment successful. {0} turns required.", i + 1);
                return;
            }
        }
        Console.WriteLine("Robot stuck at {0}. Experiment failed.", string.Join(" ", Location(room, 'S')));
    }
    static void Move(char[][] jag, char direction)
    {
        int[] position = Location(jag, 'S');
        switch (direction)
        {
            case 'D':
                for (int i = 1; i <= jag.Length; i++)
                {
                    int rowProposal = (position[0] + i) % jag.Length;
                    if (jag[rowProposal].Length > position[1])
                    {
                        if (rowProposal != position[0])
                        {
                            int[] targetD = { rowProposal, position[1] };
                            Transfer(jag, position, targetD);
                            return;
                        }
                    }
                }
                break;
            case 'U':
                for (int i = 1; i <= jag.Length; i++)
                {
                    int rowProposal = (position[0] - i) < 0 ? jag.Length - 1 : (position[0] - i);
                    if (jag[rowProposal].Length > position[1])
                    {
                        if (rowProposal != position[0])
                        {
                            int[] targetU = { rowProposal, position[1] };
                            Transfer(jag, position, targetU);
                            return;
                        }
                    }
                }
                break;
            case 'R':
                if (jag[position[0]].Length == 1)
                {
                    return;
                }
                int newColumn = (position[1] + 1) % jag[position[0]].Length;
                int[] targetR = { position[0], newColumn };
                Transfer(jag, position, targetR);
                return;
            case 'L':
                if (jag[position[0]].Length == 1)
                {
                    return;
                }
                int newCol = position[1] == 0 ? jag[position[0]].Length - 1 : (position[1] - 1);
                int[] targetL = { position[0], newCol };
                Transfer(jag, position, targetL);
                return;
        }
    }

    static void Transfer(char[][] jag,int[] position,int[] target)
    {
        if (jag[target[0]][target[1]] != 'E')
        {
            jag[target[0]][target[1]] = jag[position[0]][position[1]];
        }
        jag[position[0]][position[1]] = 'O';
    }

    static int[] Location(char[][] jag, char symbol)
    {
        for (int i = 0; i < jag.Length; i++)
        {
            for (int j = 0; j < jag[i].Length; j++)
            {
                if (jag[i][j] == symbol)
                {
                    return new int[2] { i, j };
                }
            }
        }
        return new int[2] { -1, -1 };
    }
}