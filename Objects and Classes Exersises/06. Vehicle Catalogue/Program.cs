using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>();
        while (true)
        {
            string[] input = Console.ReadLine().Split(' ');
            if (input[0] == "End")
            {
                break;
            }
            string type = input[0];
            string brand = input[1];
            string color = input[2];
            int hPowers = int.Parse(input[3]);
            Vehicle current = new Vehicle
            {
                Type = type,
                Brand = brand,
                Color = color,
                HorsePower = hPowers
            };
            vehicles.Add(current);
        }
        while (true)
        {
            string model = Console.ReadLine();
            if (model == "Close the Catalogue")
            {
                break;
            }
            int indexOfVehicle = vehicles.FindIndex(x => x.Brand == model);
            if (indexOfVehicle != -1)
            {
                Console.WriteLine("Type: " + (vehicles[indexOfVehicle].Type=="car"?"Car":"Truck"));
                Console.WriteLine("Model: " + vehicles[indexOfVehicle].Brand);
                Console.WriteLine("Color: " + vehicles[indexOfVehicle].Color);
                Console.WriteLine("Horsepower: " + vehicles[indexOfVehicle].HorsePower);
            }
        }
        if (vehicles.Where(x => x.Type == "car").Count() == 0)
        {
            Console.WriteLine("Cars have average horsepower of: 0.00.");
        }
        else
        {
            int totalHorsePowerOfCars = vehicles.Where(x => x.Type == "car").Sum(x => x.HorsePower);
            int carsCount = vehicles.Where(x => x.Type == "car").Count();
            Console.WriteLine("Cars have average horsepower of: {0:F2}.", (double)totalHorsePowerOfCars / carsCount);
        }
        if (vehicles.Where(x => x.Type == "truck").Count() == 0)
        {
            Console.WriteLine("Trucks have average horsepower of: 0.00.");
        }
        else
        {
            int totalHorsePowerOfTrucks = vehicles.Where(x => x.Type == "truck").Sum(x => x.HorsePower);
            int trucksCount = vehicles.Where(x => x.Type == "truck").Count();
            Console.WriteLine("Trucks have average horsepower of: {0:F2}.", (double)totalHorsePowerOfTrucks / trucksCount);
        }
    }
}
class Vehicle
{
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public int HorsePower { get; set; }
}