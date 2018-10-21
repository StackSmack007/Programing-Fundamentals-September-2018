using System;
using System.Text.RegularExpressions;
//11:55
class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        string didiMonPattern = @"[^a-zA-Z-]+";
        string bojoMonPattern = @"[A-Za-z]+-[A-Za-z]+";
        while (true)
        {
            
            Match didiMactch = Regex.Match(text, didiMonPattern);
            if (!didiMactch.Success) return;
            Console.WriteLine(didiMactch.Value);
            text = RemoveFirstSubstring(text,didiMactch.Value);

            Match bojoMactch = Regex.Match(text, bojoMonPattern);
            if (!bojoMactch.Success) return;
            Console.WriteLine(bojoMactch.Value);
            text = RemoveFirstSubstring(text, bojoMactch.Value);
        }
    }

    static string RemoveFirstSubstring(string text, string word)
    {
        int indexOfFirstOccurance = text.IndexOf(word);
        string textFixed = text.Remove(0, word.Length+indexOfFirstOccurance);
        return textFixed;
    }
}
//12:30