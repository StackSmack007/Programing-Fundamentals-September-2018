using System;
using System.Linq;
using System.Numerics;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Snow[] snowings = new Snow[number];
        for (int i = 0; i < number; i++)
        {
            Snow snow = new Snow
            {
                SnowballSnow = int.Parse(Console.ReadLine()),
                SnowballTime = int.Parse(Console.ReadLine()),
                SnowballQuality = int.Parse(Console.ReadLine())
            };
            snow.Value();
            snowings[i] = snow;
        }
        Snow snowResult = snowings.OrderByDescending(x => x.SnowballValue).First();
        Console.WriteLine($"{snowResult.SnowballSnow} : {snowResult.SnowballTime} = {snowResult.SnowballValue} ({snowResult.SnowballQuality})");
    }
}
class Snow
{
    public int SnowballSnow { get; set; }
    public int SnowballTime { get; set; }
    public int SnowballQuality { get; set; }
    public BigInteger SnowballValue { get; set; } = 0;
    public void Value()
    {
        SnowballValue = BigInteger.Pow(SnowballSnow / SnowballTime, SnowballQuality);
    }
}