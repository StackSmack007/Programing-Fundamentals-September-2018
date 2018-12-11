using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        ulong totalCountOfPhotoes = ulong.Parse(Console.ReadLine());//number
        ulong filtherTimeOf1Photo = ulong.Parse(Console.ReadLine());//sec
        double percentageOfGoodPhotoes = double.Parse(Console.ReadLine());
        ulong photoesToBeUploaded = (ulong)Math.Ceiling(percentageOfGoodPhotoes * totalCountOfPhotoes / 100.0);
        ulong uploadTimeFor1Pic = ulong.Parse(Console.ReadLine());
        DateTime time1 = DateTime.Now;
        var time2=time1.AddSeconds(photoesToBeUploaded * uploadTimeFor1Pic+totalCountOfPhotoes*filtherTimeOf1Photo);
        var timeDiff = time2 - time1;
        Console.WriteLine(timeDiff.ToString(@"d\:hh\:mm\:ss"));
    }
}