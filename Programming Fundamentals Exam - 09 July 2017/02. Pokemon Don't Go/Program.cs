using System;
using System.Collections.Generic;
using System.Linq;
//10:20
class Program
{
    static void Main()
    {
        List<int> array = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        int sum = 0;
        while (array.Count > 0)
        {
            int index = int.Parse(Console.ReadLine());
            int removedItem = 0;
            if (index < 0)
            {
                removedItem = array[0];
                array[0] = array[array.Count - 1];
                AddOrSubtractElement(array, removedItem);
            }
            else if (index >= array.Count)
            {
                removedItem = array[array.Count - 1];
                array[array.Count - 1] = array[0];
                AddOrSubtractElement(array, removedItem);
            }
            else
            {
                removedItem = array[index];
                array.RemoveAt(index);
                AddOrSubtractElement(array, removedItem);
            }

            sum += removedItem;
        }

        Console.WriteLine(sum);
    }
    static void AddOrSubtractElement(List<int> arr, int element)
    {
        for (int i = 0; i < arr.Count; i++)
        {
            {
                if (arr[i] <= element)
                {
                    arr[i] += element;
                }
                else
                {
                    arr[i] -= element;
                }
            }
        }
    }
}
//11:00t