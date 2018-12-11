using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, ulong>> rootFileSize = new Dictionary<string, Dictionary<string, ulong>>();
        int n = int.Parse(Console.ReadLine());
        string pattern = @"(.+)\\(.+);(\d+)";
        for (int i = 0; i < n; i++)
        {
            Match match = Regex.Match(Console.ReadLine(), pattern);
            string rooting = match.Groups[1].Value;
            string file = match.Groups[2].Value;
            ulong size = ulong.Parse(match.Groups[3].Value);
            if (!rootFileSize.ContainsKey(rooting))
            {
                rootFileSize[rooting] = new Dictionary<string, ulong> { { file, size } };
            }
            else
            {
                rootFileSize[rooting][file] = size;
            }
        }
        string[] input = Console.ReadLine().Split(' ');
        string fileType = input[0];
        string root = input[2];
        Dictionary<string, ulong> result = new Dictionary<string, ulong>();
        foreach (var kvp in rootFileSize.Where(x => x.Key.Substring(0, root.Length) == root))
        {
            foreach (var pair in kvp.Value.Where(x => x.Key.Split('.').Last() == fileType))
            {
                result[pair.Key] = pair.Value;
            }
        }
        if (result.Count == 0)
        {
            Console.WriteLine("No");
        }
        else
        {
            foreach (var kvp in result.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} KB ");
            }
        }
    }
}