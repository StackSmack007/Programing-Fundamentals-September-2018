using System;
class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        int indexOfLastSlash=input.LastIndexOf("\\")+1;
        string fileAndExtension = input.Substring(indexOfLastSlash,input.Length-indexOfLastSlash);
        int indexOfLastDot = fileAndExtension.LastIndexOf(".");
        string file = fileAndExtension.Substring(0, indexOfLastDot);
        string extension = fileAndExtension.Substring(indexOfLastDot+1, fileAndExtension.Length - indexOfLastDot-1);
        Console.WriteLine("File name: "+file);
        Console.WriteLine("File extension: " + extension);
    }
}