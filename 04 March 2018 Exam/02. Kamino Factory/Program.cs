using System;
using System.Linq;
class Program
{
    static void Main()
    {
        int bestLength = 0;
        int bestIndex = int.MaxValue;
        int[] bestDNA = new int[int.Parse(Console.ReadLine())];
        int seqNumber = 0;
        int counter = 0;
        while (true)
        {
            string inputString = Console.ReadLine();
            if (inputString == "Clone them!")
            {
                Console.WriteLine($"Best DNA sample {seqNumber} with sum: {bestDNA.Sum()}.\n{string.Join(" ", bestDNA)}");
                return;
            }
            counter++;
            int[] input = inputString.Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int currentIndexBest = 0;
            int subsequenceLengthMax = 0;
            int subsequenceLength = 0;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] == 1)
                {
                    subsequenceLength++;
                }
                if (subsequenceLength >= subsequenceLengthMax)
                {
                    if (i == 0 & input[i] == 1)
                    {
                        subsequenceLengthMax = subsequenceLength;
                        currentIndexBest = 0;
                    }
                    else if (input[i] == 0 & i < input.Length - 1)
                    {
                        subsequenceLengthMax = subsequenceLength;
                        currentIndexBest = i + 1;
                        subsequenceLength = 0;
                    }
                }
            }
            if (subsequenceLengthMax > bestLength
                || (subsequenceLengthMax == bestLength & currentIndexBest < bestIndex)
                || (subsequenceLengthMax == bestLength & currentIndexBest == bestIndex & input.Sum() > bestDNA.Sum()))
            {
                bestIndex = currentIndexBest;
                bestLength = subsequenceLengthMax;
                bestDNA = input;
                seqNumber = counter;
            }
        }
    }
}