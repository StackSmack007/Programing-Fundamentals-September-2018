using System;
class Program
{
    static void Main()
    {
        NumberOfValues(Console.ReadLine());
    }

    static void NumberOfValues(string input)
    {
        int vowelsNumber = 0;
        foreach (char letter in input)
        {
            if (letter == 'a'
                || letter == 'e'
                || letter == 'i'
                || letter == 'o'
                || letter == 'u'
                || letter == 'A'
                || letter == 'E'
                || letter == 'I'
                || letter == 'O'
                || letter == 'U')
            {
                vowelsNumber++;
            }
        }

        Console.WriteLine(vowelsNumber);
    }
}