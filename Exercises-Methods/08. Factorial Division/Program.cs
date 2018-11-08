using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        Console.WriteLine("{0:F2}",Factoriel(num1)/Factoriel(num2));
    }

    static BigInteger Factoriel(int number)
    {
        if (number == 0) return 1;
        BigInteger result = 1;
        for (int i = 2; i <= number; i++)
        {
            result *= i;
        }
        return result;
    }
}