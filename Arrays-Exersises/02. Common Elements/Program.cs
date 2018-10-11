using System;
class Program
{
    static void Main()
    {
        string[] arr1 = Console.ReadLine().Split(' ');
        string[] arr2 = Console.ReadLine().Split(' ');
         foreach (var item in arr2)
        {
            foreach (var element in arr1)
            {
                if (item == element)
                {
                    Console.Write(item + " ");
                }
            }
        }
        Console.WriteLine();
    }
}