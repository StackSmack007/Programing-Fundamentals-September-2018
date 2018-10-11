using System;
class Program
{
    static void Main()
    {
        string[] array = Console.ReadLine().Split(' ');
        int repeatanceMost = 0;
        string elementToRepeatMost = "";
        for (int i = 0; i < array.Length - 1; i++)
        {
            string currentElement = array[i];
            int currentRepeatance = 1;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (currentElement == array[j])
                {
                    currentRepeatance++;
                    if (currentRepeatance > repeatanceMost)
                    {
                        repeatanceMost = currentRepeatance;
                        elementToRepeatMost = currentElement;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        for (int i = 0; i < repeatanceMost; i++)
        {
            Console.Write(elementToRepeatMost + " ");
        }
        Console.WriteLine();
    }
}