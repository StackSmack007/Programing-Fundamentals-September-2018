using System;
using System.Numerics;
//16:15
class Program
{
    static void Main()
    {
        int sitesNumber = int.Parse(Console.ReadLine());
        byte ID = byte.Parse(Console.ReadLine());
        BigInteger securityToken = 1;
        decimal sumOfLosses = 0m;
        string[] sites = new string[sitesNumber];
        for (int i = 0; i < sitesNumber; i++)
        {
            string[] inputArr = Console.ReadLine().Split(' ');
            sites[i] = inputArr[0];
            sumOfLosses += decimal.Parse(inputArr[1]) * decimal.Parse(inputArr[2]);
            securityToken *= ID;
        }
        foreach (var item in sites)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine($"Total Loss: {sumOfLosses:F20}");
        Console.WriteLine("Security Token: " + securityToken);
    }
}
//16:40