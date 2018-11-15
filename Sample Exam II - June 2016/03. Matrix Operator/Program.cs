using System;
using System.Collections.Generic;
using System.Linq;
//15:40
class Program
{
    static void Main()
    {
        int numberOfRows = int.Parse(Console.ReadLine());
        List<List<int>> matrix = new List<List<int>>();
        for (int i = 0; i < numberOfRows; i++)
        {
            List<int> currentRow = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            matrix.Add(currentRow);
        }
        while (true)
        {
            string[] commandRow = Console.ReadLine().Split(' ');
            if (commandRow[0] == "end")
            {
                break;
            }
            string command = commandRow[0];
            if (command == "remove")
            {
                string evenOddPositiveNegative = commandRow[1];
                string colOrRow = commandRow[2];
                int index = int.Parse(commandRow[3]);
                if (colOrRow == "col")
                {
                    foreach (List<int> row in matrix.Where(x => x.Count > index))
                    {
                        if (row[index] % 2 == 0 && evenOddPositiveNegative == "even" ||
                            row[index] % 2 != 0 && evenOddPositiveNegative == "odd" ||
                            row[index] >= 0 && evenOddPositiveNegative == "positive" ||
                            row[index] < 0 && evenOddPositiveNegative == "negative")
                        {
                            row.RemoveAt(index);
                        }
                    }
                }
                else if (colOrRow == "row" && matrix.Count > index)
                {
                    List<int> temporary = new List<int>();
                    for (int i = 0; i < matrix[index].Count; i++)
                    {
                        if (matrix[index][i] % 2 == 0 && evenOddPositiveNegative == "even" ||
                            matrix[index][i] % 2 != 0 && evenOddPositiveNegative == "odd" ||
                            matrix[index][i] >= 0 && evenOddPositiveNegative == "positive" ||
                            matrix[index][i] < 0 && evenOddPositiveNegative == "negative")
                        {
                            continue;
                        }
                        temporary.Add(matrix[index][i]);
                    }
                    matrix[index] = temporary;
                }
            }
            else if (command == "swap")
            {
                int firstRowIndex = int.Parse(commandRow[1]);
                int secondRowIndex = int.Parse(commandRow[2]);
                List<int> temporary = matrix[firstRowIndex];
                matrix[firstRowIndex] = matrix[secondRowIndex];
                matrix[secondRowIndex] = temporary;
            }
            else if (command == "insert")
            {
                int rowIndex = int.Parse(commandRow[1]);
                int number = int.Parse(commandRow[2]);
                if (matrix.Count > rowIndex)
                {
                    matrix[rowIndex].Insert(0, number);
                }
            }
        }
        foreach (var row in matrix)
        {
            foreach (var item in row)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
//18:10