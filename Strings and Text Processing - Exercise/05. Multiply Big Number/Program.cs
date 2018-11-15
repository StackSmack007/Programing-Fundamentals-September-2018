using System;
using System.Text;

class Program
{
    static void Main()
    {
        string firstNumber = Console.ReadLine().TrimStart('0');
        int secondNumber = int.Parse(Console.ReadLine());
        if (secondNumber==0)
        {
            Console.WriteLine(0);return;
        }
        StringBuilder sb = new StringBuilder();
        int hasOne = 0;
        for (int i = firstNumber.Length - 1; i >= 0; i--)
        {
            int firstNumberLastDigit = firstNumber[i] - '0';
            int localRes = firstNumberLastDigit * secondNumber + hasOne;
            sb.Append(localRes % 10);
            hasOne = localRes / 10;
            if (i== 0 && hasOne>0)
            {
                sb.Append(hasOne);
            }
        }
        var result = sb.ToString().ToCharArray();
        Array.Reverse(result);
        Console.WriteLine(string.Join("",result));
    }
}