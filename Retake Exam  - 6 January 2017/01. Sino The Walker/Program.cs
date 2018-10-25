using System;
using System.Globalization;
//11:30
class Program
    {
        static void Main()
        {
        var startingHour = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
        uint steps = (uint.Parse(Console.ReadLine()))%(24*60*60);
        uint secondsFor1Step= (uint.Parse(Console.ReadLine()))%(24*60*60);
        var arrivalHour = startingHour.AddSeconds(secondsFor1Step * steps);
        Console.WriteLine("Time Arrival: "+arrivalHour.ToString("HH:mm:ss"));
        }
    }
//12:00