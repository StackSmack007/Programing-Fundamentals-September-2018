using System;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(", ");
        Func<string, bool> isValid = (x =>
                {
                    bool result = true;
                    if (x.Length > 16 || x.Length < 3)
                    {
                        result = false;
                    }
                    foreach (char letter in x)
                    {
                        if (!Char.IsLetter(letter) & letter != '_' & letter != '-' & !Char.IsDigit(letter))
                        {
                            result = false;
                        }
                    }
                    return result;
                });
        foreach (var item in input)
        {
            if (isValid(item))
            {
                Console.WriteLine(item);
            }
        }
    }
}