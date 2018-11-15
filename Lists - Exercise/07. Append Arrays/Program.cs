using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] arrayMain = Console.ReadLine().Split('|').Select(x=>x.Trim()).ToArray();
        string[] result = new string[arrayMain.Length];
        for (int i = arrayMain.Length - 1; i >= 0; i--)
        {
            result[arrayMain.Length - 1 - i] = arrayMain[i];
        }
        string[] resultNoEmptySpaces = string.Join(" ", result).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine(string.Join(" ",resultNoEmptySpaces));
    }
}