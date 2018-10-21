using System;
using System.Collections.Generic;
using System.Linq;
//12:30
class Program
{
    static void Main()
    {
        Dictionary<string, List<PokemonEvolution>> pokemons = new Dictionary<string, List<PokemonEvolution>>();
        while (true)
        {
            string[] inputArr = Console.ReadLine().Split(new char[] { '-', ' ', '>' }, StringSplitOptions.RemoveEmptyEntries);
            string name = inputArr[0];
            if (inputArr.Length == 1)
            {
                if (name == "wubbalubbadubdub")
                {
                    goto printAll;
                }
                else if (pokemons.ContainsKey(name))
                {
                    Console.WriteLine("# " + name);
                    foreach (PokemonEvolution pokeStat in pokemons[name])
                    {
                        Console.WriteLine("{0} <-> {1}", pokeStat.EvolutionType, pokeStat.EvolutionScore);
                    }
                }
                continue;
            }
            PokemonEvolution current = new PokemonEvolution();
            current.FillStats(inputArr);
            if (!pokemons.ContainsKey(name))
            {
                pokemons[name] = new List<PokemonEvolution>();
                pokemons[name].Add(current);
            }
            else
            {
                pokemons[name].Add(current);
            }

        }

    printAll:
        foreach (var kvp in pokemons)
        {
            Console.WriteLine("# " + kvp.Key);
            foreach (var pokeStat in kvp.Value.OrderByDescending(x => x.EvolutionScore))
            {
                Console.WriteLine("{0} <-> {1}", pokeStat.EvolutionType, pokeStat.EvolutionScore);
            }
        }
    }
}

class PokemonEvolution
{
    public string EvolutionType { get; set; }
    public int EvolutionScore { get; set; }
    public void FillStats(string[] array)
    {
        EvolutionType = array[1];
        EvolutionScore = int.Parse(array[2]);
    }
}
//13:00