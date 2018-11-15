using System;


class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        int lastindexFound = input.IndexOf(">");
        int inheritancePower = 0;
        
        while (lastindexFound!=-1)
        {
            int strenght = Math.Min(input[lastindexFound + 1] - '0'+inheritancePower,input.Length-lastindexFound-1);

            int nextIndex = input.IndexOf(">", lastindexFound+1);

            if (nextIndex -lastindexFound -1 <strenght & nextIndex!=-1)
            {
                inheritancePower = strenght - (nextIndex - lastindexFound - 1);
                strenght = nextIndex - lastindexFound - 1;
            }
            input = input.Remove(lastindexFound + 1, strenght);
            lastindexFound = input.IndexOf(">", lastindexFound + 1);
        }
        Console.WriteLine(input);
    }
}