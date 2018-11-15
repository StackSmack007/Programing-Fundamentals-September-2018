using System;
using System.Text;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        foreach (char letter in input)
        {
            sb.Append((char)(letter + 3));
        }
        string result = sb.ToString();
        Console.WriteLine(result);
    }
}