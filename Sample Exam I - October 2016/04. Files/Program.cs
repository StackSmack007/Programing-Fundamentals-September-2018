using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
//12:05
class Program
{
    static void Main()
    {
        Dictionary<string, List<File>> directoryAndFiles = new Dictionary<string, List<File>>();
        int numberOfInputs = int.Parse(Console.ReadLine());
        string pattern = @"(.+)\\\s*(.+);(\d+)";
        for (int i = 0; i < numberOfInputs; i++)
        {
            string inputLine = Console.ReadLine();
            Match matchRow = Regex.Match(inputLine, pattern);
            string root = matchRow.Groups[1].Value;
            string fileName = matchRow.Groups[2].Value;
            ulong size = ulong.Parse(matchRow.Groups[3].Value);
            File fileCurrent = new File()
            {
                NameAndExtension = fileName,
                SizeInKB = size,
            };
            if (!directoryAndFiles.ContainsKey(root))
            {
                directoryAndFiles[root] = new List<File> { fileCurrent };
            }
            else
            {
                int index = directoryAndFiles[root].FindIndex(x => x.NameAndExtension == fileName);
                if (index==-1)
                {
                    directoryAndFiles[root].Add(fileCurrent);
                }
                else
                {
                    directoryAndFiles[root][index] = fileCurrent;        
                }
            }
        }

        string[] command = Console.ReadLine().Split(' ').Where(x => x != "in").ToArray();
        List<File> result = new List<File>();
        foreach (var kvp in directoryAndFiles.Where(x=>x.Key.Substring(0,command[1].Length)==command[1]))
        {
            foreach (var item in kvp.Value.Where(x => x.NameAndExtension.Contains("." + command[0])))
            {
                result.Add(item);
            }
        }
        if (result.Count==0)
        {
            Console.WriteLine("No");
            return;
        }
        result = result.OrderByDescending(x => x.SizeInKB).ThenBy(x => x.NameAndExtension).ToList();
        foreach (File file in result)
        {
Console.WriteLine($"{file.NameAndExtension} - { file.SizeInKB} KB");
        }
    }
}

class File
{
    public string NameAndExtension { get; set; }
    public ulong SizeInKB { get; set; }
}
//13:45