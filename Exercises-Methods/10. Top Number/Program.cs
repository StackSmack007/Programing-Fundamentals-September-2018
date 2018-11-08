using System;
class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
       PrintTopNumbers(number);
    }

    static void PrintTopNumbers(int number)
    {
        for (int i = 8; i <= number; i++)
        {
            if (IsTopNumber(i))
            {
                Console.WriteLine(i);
            }
        }
    }

    static bool IsTopNumber(int num)
    {
        int numCopy = num;
        int sum = 0;
        bool hasOddDigit = false;
        while (numCopy>0)
        {
            if ((numCopy % 10) % 2!=0)
            {
                hasOddDigit = true;
            }
            sum += numCopy % 10;
            numCopy /= 10;
        }

        if (hasOddDigit & sum % 8 == 0) 
        {
            return true;
        }

        return false;
    }
}