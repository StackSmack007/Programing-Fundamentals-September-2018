using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] personMoneyArr = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
        List<Person> persons = new List<Person>();
        for (int i = 0; i < personMoneyArr.Length; i += 2)
        {
            Person current = new Person
            {
                Name = personMoneyArr[i],
                Money = decimal.Parse(personMoneyArr[i + 1]),
            };
            persons.Add(current);
        }
        string[] productCostArr = Console.ReadLine().Split(new char[] { ';', '=' },StringSplitOptions.RemoveEmptyEntries);
        List<Product> products = new List<Product>();
        for (int i = 0; i < productCostArr.Length; i += 2)
        {
            Product current = new Product
            {
                Name = productCostArr[i],
                Cost = decimal.Parse(productCostArr[i + 1]),
            };
            products.Add(current);
        }
        while (true)
        {
            string[] input = Console.ReadLine().Split(' ');

            if (input[0] == "END")
            {
                break;
            }
            string personName = input[0];
            int indexOfPerson = persons.FindIndex(x => x.Name == personName);
            if (indexOfPerson == -1) continue;
            decimal personMoney = persons[indexOfPerson].Money;

            string productName = input[1];
            int indexOfProduct = products.FindIndex(x => x.Name == productName);
            if (indexOfProduct == -1) continue;
            decimal productCost = products[indexOfProduct].Cost;

            if (personMoney < productCost)
            {
                Console.WriteLine($"{personName} can't afford {productName}");
                continue;
            }
            Console.WriteLine($"{personName} bought {productName}");
            persons[indexOfPerson].Money -= productCost;
            persons[indexOfPerson].BagOfGodies.Add(products[indexOfProduct]);
        }
        foreach (var customer in persons)
        {
            if (customer.BagOfGodies.Count==0)
            {
                Console.WriteLine(customer.Name+" - Nothing bought");
            }
            else
            {
                string NameAndPurchases = customer.Name + " - ";
                foreach (Product item in customer.BagOfGodies)
                {
                    NameAndPurchases += item.Name + ", ";
                }
                Console.WriteLine(NameAndPurchases.TrimEnd(',',' '));
            }
        }
    }
}
class Product
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
}
class Person
{
    public string Name { get; set; }
    public decimal Money { get; set; }
    public List<Product> BagOfGodies { get; set; } = new List<Product>();
}