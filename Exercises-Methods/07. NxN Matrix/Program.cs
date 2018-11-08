using System;
using System.Text;
class Program
{
    static void Main()
    {
        PrintMatrixNxN(int.Parse(Console.ReadLine()));
    }

    static void PrintMatrixNxN(int N)
    {
        StringBuilder row = new StringBuilder();
        for (int j = 0; j < N; j++)
        {
            row.Append(N + " ");
        }
        string result = row.ToString().Trim();
        for (int j = 0; j < N; j++)
        {
            Console.WriteLine(result);
        }
    }
}