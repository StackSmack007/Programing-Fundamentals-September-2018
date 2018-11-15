using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string[] delimiters = Console.ReadLine().Split(' ');
        List<Drink> data = new List<Drink>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end of info")
            {
                break;
            }
            string[] splittedInput = input.Split(delimiters[0]);
            if (splittedInput.Length > 1)
            {
                string person = splittedInput[0];
                string beverage = splittedInput[1];
                int beverageIndex = data.FindIndex(x => x.NameOfDrink == beverage);
                if (beverageIndex != -1)
                {
                    data[beverageIndex].Drinkers.Add(person);
                }
                else
                {
                    Drink current = new Drink
                    {
                        NameOfDrink = beverage,
                        Drinkers = new List<string> { person }
                    };
                    data.Add(current);
                }
            }
            else
            {
                splittedInput = input.Split(delimiters[1]);
                string beverage = splittedInput[0];
                int quantity = int.Parse(splittedInput[1]);
                int beverageIndex = data.FindIndex(x => x.NameOfDrink == beverage);
                if (beverageIndex != -1)
                {
                    data[beverageIndex].Quantity += quantity;
                }
                else
                {
                    Drink current = new Drink
                    {
                        NameOfDrink = beverage,
                        Quantity = quantity
                    };
                    data.Add(current);
                }
            }
        }
        List<Drink> notNullDrinks = new List<Drink>();
        foreach (Drink drink in data)
        {
            if (drink.Quantity == 0)
            {
                Console.WriteLine("Out of {0}", drink.NameOfDrink);
            }
            else
            {
                notNullDrinks.Add(drink);
            }
        }
        data = notNullDrinks;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end of week")
            {
                break;
            }
            string[] splittedInput = input.Split(' ');
            string person = splittedInput[0];
            int quantity = int.Parse(splittedInput[1]);
            int index = data.FindIndex(x => x.Drinkers.Contains(person));
            if (index >= 0)
            {
                if (quantity >= data[index].Quantity)
                {
                    Console.WriteLine("Out of {0}", data[index].NameOfDrink);
                    data[index].Quantity = 0;
                }
                else
                {
                    data[index].Quantity -= quantity;
                }
            }
        }
        Console.WriteLine("Coffee Left:");
        foreach (Drink coffe in data.Where(x => x.Quantity > 0).OrderByDescending(x => x.Quantity))
        {
            Console.WriteLine(coffe.NameOfDrink + " " + coffe.Quantity);
        }

        Console.WriteLine("For:");
        foreach (Drink coffe in data.OrderBy(x => x.NameOfDrink).Where(x => x.Quantity > 0))
        {
            foreach (string person in coffe.Drinkers.OrderByDescending(x => x))
            {
                Console.WriteLine(person + " " + coffe.NameOfDrink);
            }
        }
    }
}

class Drink
{
    public string NameOfDrink { get; set; }
    public int Quantity { get; set; } = 0;
    public List<string> Drinkers { get; set; }
}