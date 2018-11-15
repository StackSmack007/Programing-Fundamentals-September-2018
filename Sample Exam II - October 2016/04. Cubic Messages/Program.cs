using System;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string pattern = @"([\d]+)([a-zA-Z]+)([^a-zA-Z]*)";
        while (true)
        {
            string inputText = Console.ReadLine();
            if (inputText=="Over!")
            {
                return;
            }

            int lenghtOfMessage = int.Parse(Console.ReadLine());
            Match match = Regex.Match(inputText, pattern);
            if (match.Value != inputText||match.Groups[2].Value.Length!=lenghtOfMessage)
            {
                continue;
            }
            string message = match.Groups[2].Value;
            string indexesPrimary = match.Groups[1].Value + match.Groups[3].Value;
            string resultMessage = "";
            foreach (char symbol in indexesPrimary.Where(x=>x>='0'& x <= '9'))
            {
                int index = symbol-'0';
                if (index>=lenghtOfMessage)
                {
                    resultMessage += " ";
                }
                else
                {
                    resultMessage += message[index];
                }
            }
            Console.WriteLine(message+" == "+resultMessage);
        }
    }
}