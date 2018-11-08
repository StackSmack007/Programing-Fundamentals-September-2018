using System;
//18:30
class Program
{
    static void Main()
    {
        int wingFlaps = int.Parse(Console.ReadLine());
        double distanceFor1000wingFlaps = double.Parse(Console.ReadLine());
        int endurance= int.Parse(Console.ReadLine());
        double resultDistance = distanceFor1000wingFlaps*(wingFlaps/1000.0);
        int resultTime = wingFlaps/100+5*(wingFlaps/endurance);
       
        Console.WriteLine("{0:F2} m.",resultDistance);
        Console.WriteLine("{0} s.",resultTime);
    }
}
//18:42