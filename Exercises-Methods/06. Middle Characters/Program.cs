using System;
class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        PrintMiddleCharacter(input);
    }

    static void PrintMiddleCharacter(string input)
    {
        if (input.Length % 2 == 0)
        {
            string result = input.Substring(input.Length / 2 - 1, 2);
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine(input[input.Length/2]);
        }
    }
}