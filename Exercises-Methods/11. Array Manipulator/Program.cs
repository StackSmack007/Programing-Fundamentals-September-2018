using System;
using System.Linq;
class Program
{
    static void Main()
    {
        int[] array = Console.ReadLine().Split(new char[] {' ','\t'}
                                        ,StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();
        while (true)
        {
            string[] input = Console.ReadLine().Split(' ');
            if (input[0] == "end")
            {
                break;
            }
            string command = input[0];
            switch (command)
            {
                case "exchange":
                    int index = int.Parse(input[1]);
                    Exchange(array, index);
                    break;

                case "max":
                case "min":
                    string oddOrEven = input[1];
                    PrintMaxMin(array, command, oddOrEven);
                    break;

                case "first":
                case "last":
                    int countOfNumbers = int.Parse(input[1]);
                    string EvenOrOdd = input[2];

                    PrintFirstLast(array
                        , countOfNumbers
                        , command == "first" ? true : false
                        , EvenOrOdd == "even" ? true : false);
                    break;
            }
        }

        Console.WriteLine("[" + string.Join(", ", array) + "]");
    }

    static void Exchange(int[] arr, int index)
    {
        if (index < 0 || index >= arr.Length)//the array is not changed!
        {
            Console.WriteLine("Invalid index");
            return;
        }

       // int rotations = arr.Length - index - 1;
        for (int i = 0; i < index+1; i++)
        {
            int firstElement = arr[0];
            for (int j = 0; j < arr.Length-1; j++)
            {
                arr[j] = arr[j + 1];
            }
            arr[arr.Length-1] = firstElement;
        }

    }//runs only if index is valid!

    static void PrintMaxMin(int[] arr, string maxORmin, string oddOREven)
    {
        int elementFound = maxORmin == "max" ? int.MinValue : int.MaxValue;
        int indexOf = -1;
        int expectance = oddOREven == "odd" ? 1 : 0;

        for (int i = arr.Length-1; i >= 0; i--)
        {
            if (arr[i] % 2 == expectance)
            {
                if ((maxORmin == "max" & arr[i] > elementFound) || (maxORmin == "min" & arr[i] < elementFound))
                {
                    elementFound = arr[i];
                    indexOf = i;
                }
            }
        }
        if (indexOf == -1)
        {
            Console.WriteLine("No matches");
            return;
        }

        Console.WriteLine(indexOf);
    }//usable for both max and min

    static void PrintFirstLast(int[] arr, int number, bool First = true, bool even = true)
    {
        if (number > arr.Length)
        {
            Console.WriteLine("Invalid count");
            return;
        }

        if (even)
        {
            int[] resultNotMeasured = arr.Where(x => x % 2 == 0).ToArray();
            PrintNumberOfElementsFirstOrLast(resultNotMeasured, number, First);
        }
        else
        {
            int[] resultNotMeasured = arr.Where(x => x % 2 == 1).ToArray();
            PrintNumberOfElementsFirstOrLast(resultNotMeasured, number, First);
        }
    }

    static void PrintNumberOfElementsFirstOrLast(int[] array, int number, bool First = true)
    {
        if (array.Length < number)
        {
            Console.WriteLine("[{0}]", string.Join(", ", array));
            return;
        }
        else
        {
            int skip = First == true ? 0 : array.Length - number;
            int[] result = array.Skip(skip).Take(number).ToArray();
            Console.WriteLine("[{0}]", string.Join(", ", result));
        }
    }//submethod of PrintFirstLast
}