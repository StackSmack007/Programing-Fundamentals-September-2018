using System;
using System.Linq;
//12:05

class Program
{
    static void Main()
    {
        int[] sizeOfMatrixRowsAndColumns = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int rows = sizeOfMatrixRowsAndColumns[0];
        int cols = sizeOfMatrixRowsAndColumns[1];
        int[,] matrix = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            int[] currentRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int j = 0; j < currentRow.Length; j++)
            {
                matrix[i, j] = currentRow[j];
            }
        }
        int[] targetCell = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int begginRowIndex = Math.Max(0, targetCell[0] - 1);
        int endRowIndex = Math.Min(rows - 1, targetCell[0] + 1);

        int begginColumnIndex = Math.Max(0, targetCell[1] - 1);
        int endColumnIndex = Math.Min(cols - 1, targetCell[1] + 1);
        int targetValue = matrix[targetCell[0], targetCell[1]];
        int sumOfAllOthers = 0;
        for (int i = begginRowIndex; i <= endRowIndex; i++)
        {
            for (int j = begginColumnIndex; j <= endColumnIndex; j++)
            {
                if (i == targetCell[0] && j == targetCell[1]) continue;
                sumOfAllOthers += matrix[i, j];
                matrix[i, j] *= targetValue;
            }
        }
        matrix[targetCell[0], targetCell[1]] *= sumOfAllOthers;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine(matrix.Length);
        Console.WriteLine(matrix.GetLength(0));
        Console.WriteLine(matrix.GetLength(1));

    }
}
//12:45