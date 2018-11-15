using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Product> orders = new List<Product>();
        string commandLine = Console.ReadLine();
        while (commandLine != "buy")
        {
            Product current = new Product();
            current.Fill(commandLine);
            int indexOfElement = orders.FindIndex(x => x.Name == current.Name);//-1 ако няма
            if (indexOfElement == -1)
            {
                orders.Add(current);
            }
            else
            {
                orders[indexOfElement].Price = current.Price;
                orders[indexOfElement].Quantity += current.Quantity;
            }
            commandLine = Console.ReadLine();
        }

        for (int i = 0; i < orders.Count; i++)
        {
            Console.WriteLine($"{orders[i].Name} -> {orders[i].Quantity * orders[i].Price:F2}");
        }
    }
}
class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public void Fill(string input)
    {
        string[] arr = input.Split(' ');
        Name = arr[0];
        Price = decimal.Parse(arr[1]);
        Quantity = int.Parse(arr[2]);
    }
}