using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<Dwarf> dwarfs = new List<Dwarf>();
        while (true)
        {
            string[] input = Console.ReadLine().Split(new char[] { '<', ':', '>',' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (string.Join(" ", input) == "Once upon a time")
            {
                break;
            }
            Dwarf dwarf = new Dwarf
            {
                Name = input[0],
                Colour = input[1],
                Physic = int.Parse(input[2])
            };
            if (dwarfs.Any(x => x.Name == dwarf.Name & x.Colour == dwarf.Colour))
            {
                for (int i = 0; i < dwarfs.Count; i++)
                {
                    if (dwarfs[i].Name == dwarf.Name & dwarfs[i].Colour == dwarf.Colour)
                    {
                        dwarfs[i].Physic = Math.Max(dwarf.Physic, dwarfs[i].Physic);
                        break;
                    }
                }
            }
            else
            {
                dwarfs.Add(dwarf);
            }
        }
        Dictionary<string, int> colourOccurance = new Dictionary<string, int>();
        foreach (var item in dwarfs)
        {
            if (colourOccurance.ContainsKey(item.Colour))
            {
                colourOccurance[item.Colour]++;
            }
            else
            {
                colourOccurance[item.Colour] = 1;
            }
        }
        foreach (var item in dwarfs)
        {
            foreach (var kvp in colourOccurance)
            {
                if (kvp.Key == item.Colour)
                {
                    item.colourOccurance = kvp.Value;
                    break;
                }
            }
        }
        foreach (var dwarf in dwarfs.OrderByDescending(x=>x.Physic).ThenByDescending(x=>x.colourOccurance))
        {
            Console.WriteLine($"({dwarf.Colour}) {dwarf.Name} <-> {dwarf.Physic}");
        }
    }
}
class Dwarf
{
    public string Name { get; set; }
    public string Colour { get; set; }
    public int Physic { get; set; }
    public int colourOccurance { get; set; }
}