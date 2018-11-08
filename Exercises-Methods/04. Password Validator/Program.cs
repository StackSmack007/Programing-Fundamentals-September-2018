using System;


class Program
{
    static void Main()
    {
        string password = Console.ReadLine();
        Validator(password);
    }

    static void Validator(string input)
    {
        if (!HasBetween6and10symbols(input))
        {
            Console.WriteLine("Password must be between 6 and 10 characters");
        }

        if (!ConsistOfSymbolsAndLettersOnly(input))
        {
            Console.WriteLine("Password must consist only of letters and digits");
        }

        if (!hasAtleast2Digits(input))
        {
            Console.WriteLine("Password must have at least 2 digits");
        }

        if (HasBetween6and10symbols(input)
            & ConsistOfSymbolsAndLettersOnly(input)
            & hasAtleast2Digits(input))
        {
            Console.WriteLine("Password is valid");
        }
    }

    static bool HasBetween6and10symbols(string input)
    {
        if (input.Length >= 6 & input.Length <= 10)
        {
            return true;
        }

        return false;
    }

    static bool ConsistOfSymbolsAndLettersOnly(string input)
    {
        foreach (char letter in input)
        {
            if (!(((int)letter - '0' < 10 & (int)letter - '0' >= 0) ||
                ((int)letter - 'A' < 25 & (int)letter - 'A' >= 0) ||
                ((int)letter - 'a' < 25 & (int)letter - 'a' >= 0)))
            {
                return false;
            }
        }

        return true;
    }

    static bool hasAtleast2Digits(string password)
    {
        int digitsCounter = 0;
        foreach (char letter in password)
        {
            if ((int)letter - '0' < 10 & (int)letter - '0' >= 0)
            {
                digitsCounter++;
            }
        }

        if (digitsCounter >= 2)
        {
            return true;
        }

        return false;
    }
}