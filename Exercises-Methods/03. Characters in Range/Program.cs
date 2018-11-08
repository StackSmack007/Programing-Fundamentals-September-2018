using System;
using System.Text;
class Program
{
    static void Main()
    {
        
        PrintCharsBetween(Console.ReadLine()[0], Console.ReadLine()[0]);
    }

    static void PrintCharsBetween(char ch1, char ch2)
    {
        char[] chars = new char[2] { (char)Math.Min((int)ch1, (int)ch2), (char)Math.Max((int)ch1, (int)ch2) };
        StringBuilder result = new StringBuilder();
        for (char i = (char)(chars[0] + 1); i < chars[1]; i++)
        {
            result.Append((char)i+" ");
        }

        Console.WriteLine(result.ToString().Trim());
    }
}