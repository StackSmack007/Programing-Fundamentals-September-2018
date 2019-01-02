using System;
using System.Collections.Generic;
using System.Linq;
namespace zad_05
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> numberName = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                string command = input[0];
                string name = input[1];
                string plateN = input.Length < 3 ? "" : input[2];
                bool plateNIsValid = true;
                if (plateN.Length != 8)
                {
                    plateNIsValid = false;
                }
                else
                {
                    string letterscheck = plateN.Remove(2, 4);
                    for (int j = 2; j < 6; j++)
                    {
                        if (plateN[j] < 48 || plateN[j] > 57) { plateNIsValid = false; }//проверява средните 4 дали са цифри!
                        if (letterscheck[j - 2] < 65 || letterscheck[j - 2] > 90) { plateNIsValid = false; }//проверява крайните 2 дали са главни букви!
                    }
                }
                if (command == "register")
                {
                    if (!numberName.ContainsKey(plateN))
                    {
                        if (plateNIsValid)
                        {
                            numberName[plateN] = name;
                            Console.WriteLine("{0} registered {1} successfully", name, plateN);
                        }
                        else
                        {
                            Console.WriteLine("ERROR: invalid license plate {0}", plateN);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: license plate {plateN} is busy");
                    }
                }
                else if (command == "unregister")
                {
                    if (numberName.ContainsValue(name))
                    {
                        Console.WriteLine("user {0} unregistered successfully", name);
                        var item = numberName.First(kvp => kvp.Value == name);
                        numberName.Remove(item.Key);
                    }
                    else
                    {
                        Console.WriteLine("ERROR: user {0} not found", name);
                    }
                }
            }
            foreach (var kvp in numberName)
            {
                Console.WriteLine($"{kvp.Value} => {kvp.Key}");
            }
        }
    }
}