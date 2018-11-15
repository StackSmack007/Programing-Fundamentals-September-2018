using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Car[] cars = new Car[n];
        for (int i = 0; i < n; i++)
        {
            cars[i] =new Car(Console.ReadLine());
        }
        string command = Console.ReadLine();
        List<Car> result = new List<Car>();
        if (command=="fragile")
        {
            result = cars.Where(x => x.CargoType == command&&x.CargoWeight<1000).ToList();
        }
        else if (command == "flamable")
        {
            result = cars.Where(x => x.CargoType == command && x.EnginePower >250).ToList();
        }
        foreach (var car in result)
        {
            Console.WriteLine(car.model);
        }
    }
}
class Car
{
    public Car(string input)
    {
        string[] arr = input.Split(' ');
        model = arr[0];
        EngineSpeed   =int.Parse(arr[1]);
        EnginePower   =int.Parse(arr[2]);
        CargoWeight   =int.Parse(arr[3]);
        CargoType = arr[4];
    }
    public string model { get; set; }
    public int EngineSpeed { get; set; }
    public int EnginePower { get; set; }
    public int CargoWeight { get; set; }
    public string CargoType { get; set; }
}