using System;
class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] {' ','\t'},StringSplitOptions.RemoveEmptyEntries);
        double result = 0;
        foreach (var item in input)
        {
            result += Value(item);
        }
        Console.WriteLine("{0:F2}",result);
    }
    static double Value(string combo)
    {
        char firstLetter = combo[0];
        combo = combo.Remove(0, 1);
        char lastLetter = combo[combo.Length - 1];
        combo = combo.Remove(combo.Length - 1, 1);
        double number = double.Parse(combo);
        if (firstLetter >= 'a' && firstLetter <= 'z')
        {
            number *= firstLetter - 'a' + 1;
        }
        else if (firstLetter >= 'A' && firstLetter <= 'Z')
        {
            number /= 1.0*(firstLetter - 'A' + 1);
        }
        if (lastLetter >= 'a' && lastLetter <= 'z')
        {
            number += lastLetter - 'a' + 1;
        }
        else if (lastLetter >= 'A' && lastLetter <= 'Z')
        {
            number -= lastLetter - 'A' + 1;
        }
        return number;
    }
}