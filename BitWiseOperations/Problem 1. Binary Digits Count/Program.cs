using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        string zeroOrOne = Console.ReadLine();
        string binary = "";
        while (number>0)
        {
            binary = number % 2 + binary;
            number /= 2;
        }
        int sum = 0;
        foreach (char symbol in binary)
        {
            sum += symbol - '0';
        }
        if (zeroOrOne == "1")
        {
            Console.WriteLine(sum);
        }
        else
        {
            Console.WriteLine(binary.Length - sum);
        }
    }
}