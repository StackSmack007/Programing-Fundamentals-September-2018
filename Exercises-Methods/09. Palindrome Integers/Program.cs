using System;
class Program
{
    static void Main()
    {

        while (true)
        {
            string inputLine = Console.ReadLine();
            if (inputLine == "END")
            {
                return;
            }

            Console.WriteLine(PalindromeCheck(inputLine).ToString().ToLower());
        }
    }

    static bool PalindromeCheck(string input)
    {
        string reversed = "";
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversed += input[i];
        }
        if (input == reversed)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}