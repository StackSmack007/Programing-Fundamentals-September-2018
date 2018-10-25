using System;
using System.Collections.Generic;
using System.Linq;
//17:10
class Program
{
    static void Main()
    {
        List<string> singers = Console.ReadLine().Split(',').Select(x => x.Trim()).ToList();
        List<string> songs = Console.ReadLine().Split(',').Select(x => x.Trim()).ToList();
        Dictionary<string, List<string>> singersAwarded = new Dictionary<string, List<string>>();

        while (true)
        {
            string[] input = Console.ReadLine().Split(',').Select(x => x.Trim()).ToArray();
            if (input[0] == "dawn")
            {
                goto print;
            }

            string singer = input[0];
            string song = input[1];
            string award = input[2];
            bool isConsidered = singers.Contains(singer) & songs.Contains(song);

            if (isConsidered)
            {
                if (!singersAwarded.ContainsKey(singer))
                {
                    singersAwarded[singer] = new List<string> { award };
                }
                else if (!singersAwarded[singer].Contains(award))
                {
                    singersAwarded[singer].Add(award);
                }
            }
        }
    print:
        if (singersAwarded.Count == 0)
        {
            Console.WriteLine("No awards");
        }
        else
        {
            foreach (var kvp in singersAwarded.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine("{0}: {1} awards", kvp.Key, kvp.Value.Count);
                foreach (string award in kvp.Value.OrderBy(x=>x))
                {
                    Console.WriteLine("--{0}", award);
                }
            }
        }
    }
}
//17:35