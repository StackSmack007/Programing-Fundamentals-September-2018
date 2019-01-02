using System;
using System.Collections.Generic;
using System.Linq;
namespace zad_11
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            var colourNameDmgHealthArmour = new Dictionary<string, Dictionary<string, double[]>>();
            for (int i = 0; i < rows; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                string type = input[0];
                string name = input[1];
                double damage = input[2] == "null" ? 45 : double.Parse(input[2]);
                double health = input[3] == "null" ? 250 : double.Parse(input[3]);
                double armour = input[4] == "null" ? 10 : double.Parse(input[4]);
                double[] dmgHealthArmour = { damage, health, armour };
                Dictionary<string, double[]> nameDamageHealthArmour = new Dictionary<string, double[]>();
                nameDamageHealthArmour[name] = dmgHealthArmour;
                if (!colourNameDmgHealthArmour.ContainsKey(type))
                {
                    colourNameDmgHealthArmour[type] = nameDamageHealthArmour;
                }
                else
                {
                    colourNameDmgHealthArmour[type][name] = dmgHealthArmour;
                }
            }
            foreach (var kvp in colourNameDmgHealthArmour)
            {
                int n = 0;
                double avdam = 0.0;
                double avhea = 0.0;
                double avarm = 0.0;
                foreach (var pair in kvp.Value)
                {
                    n++;
                    avdam += colourNameDmgHealthArmour[kvp.Key][pair.Key][0];
                    avhea += colourNameDmgHealthArmour[kvp.Key][pair.Key][1];
                    avarm += colourNameDmgHealthArmour[kvp.Key][pair.Key][2];
                }
                avdam /= n;
                avhea /= n;
                avarm /= n;
                Console.WriteLine($"{kvp.Key}::({avdam:F2}/{avhea:F2}/{avarm:F2})");
                foreach (var pair in kvp.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine("-{0} -> damage: {1:F0}, health: {2:F0}, armor: {3:F0}", pair.Key, colourNameDmgHealthArmour[kvp.Key][pair.Key][0], colourNameDmgHealthArmour[kvp.Key][pair.Key][1], colourNameDmgHealthArmour[kvp.Key][pair.Key][2]);
                }
            }
        }
    }
}

