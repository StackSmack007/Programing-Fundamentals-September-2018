using System;
using System.Collections.Generic;

namespace zad_7
{
    class Program
    {
        static void Main()
        {
            NestedDictionary<string, string, int> rechnik = new NestedDictionary<string, string, int>();
            



          
          rechnik["stranica 2ra"]["zaglavie2"] = 13;
           rechnik["stranica 3ta"]["zaglavie3"] = 15;
            foreach (var kvp in rechnik)
            {
                Console.WriteLine(kvp.Key);
                foreach (var zagtext in kvp.Value)
                {
Console.WriteLine($"{zagtext.Key}     +      {zagtext.Value}");
                }
            }


            
        }
    }
}
