using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
//11:30
class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int n = N;
        int M = int.Parse(Console.ReadLine());
        byte Y = byte.Parse(Console.ReadLine());
        long pokes = 0;

        while (n >= M)
        {
            if (2.0*n==N&Y!=0)
            {
                n /= Y;
                continue;
            }

            n -= M;
            pokes++;
        }

        Console.WriteLine(n);
        Console.WriteLine(pokes);
    }
}
//11:53