using System;
class Program
{
    static void Main()
    {
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());
        Console.WriteLine(Subtract2(Add2(num1,num2),num3));
    }

    static int Add2(int num1, int num2)
    {
        return num1 + num2;
    }

    static int Subtract2(int num1, int num2)
    {
        return num1 - num2;
    }
}