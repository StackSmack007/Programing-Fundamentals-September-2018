using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int numberOfCars = int.Parse(Console.ReadLine());
        Dictionary<string, Car> modelStats = new Dictionary<string, Car>();
        for (int i = 0; i < numberOfCars; i++)
        {
            string[] inputRow = Console.ReadLine().Split(' ');
            Car current = new Car
            {
                FuelAmaunt = double.Parse(inputRow[1]),
                FuelPer100km = double.Parse(inputRow[2]),
                DistancePassed = 0
            };
            modelStats[inputRow[0]] = current;
        }
        while (true)
        {
string[] inputRow = Console.ReadLine().Split(' ');
            if (inputRow[0]== "End")
            {
                break;
            }
            string carModel = inputRow[1];
            double distance = double.Parse(inputRow[2]);
            double distanceCappacity = modelStats[carModel].FuelAmaunt / modelStats[carModel].FuelPer100km;
            if (distance>distanceCappacity)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                continue;
            }
            modelStats[carModel].DistancePassed += distance;
            modelStats[carModel].FuelAmaunt -= modelStats[carModel].FuelPer100km * distance;
        }
        foreach (var kvp in modelStats)
        {
            Console.WriteLine($"{kvp.Key} {kvp.Value.FuelAmaunt:F2} {kvp.Value.DistancePassed:F0}");
        }
    }
}
class Car
{
    public double FuelAmaunt { get; set; }
    public double FuelPer100km { get; set; }
    public double DistancePassed { get; set; }
}