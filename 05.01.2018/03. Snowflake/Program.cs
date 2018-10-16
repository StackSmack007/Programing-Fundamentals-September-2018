using System;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string surfacePattern = @"[\W]+";
        string mantlePattern = @"[\d_]+";
        string surfaceMantleCoreMantleCorePattern = @"[\W]+[\d_]+([a-zA-Z]+)[\d_]+[\W]+";
        bool isValid = true;
        string core = "";
        for (int i = 1; i <= 5; i++)
        {
            string input = Console.ReadLine();
            switch (i)
            {
                case 1:
                case 5:
                    Match checkSurface = Regex.Match(input, surfacePattern);
                    if (checkSurface.Value != input)
                    {
                        isValid = false;
                    }
                    break;
                case 2:
                case 4:
                    Match checkMantle = Regex.Match(input, mantlePattern);
                    if (checkMantle.Value != input)
                    {
                        isValid = false;
                    }
                    break;
                case 3:
                    Match checksurfaceMantleCore = Regex.Match(input, surfaceMantleCoreMantleCorePattern);
                    if (checksurfaceMantleCore.Value != input)
                    {
                        isValid = false;
                    }
                    core = checksurfaceMantleCore.Groups[1].Value;
                    break;
            }
        }
        if (isValid)
        {
            Console.WriteLine("Valid");
            Console.WriteLine(core.Length);
        }
        else
        {
            Console.WriteLine("Valid");
        }
    }
}