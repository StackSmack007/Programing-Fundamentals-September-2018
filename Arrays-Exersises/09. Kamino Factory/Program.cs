using System;
using System.Linq;
class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int[] result = new int[number];
        int bestStartIndex = number - 1;
        int bestSum = 0;
        int bestLongestSequence = 0;
        int bestSequenceNumber = 1;
        int sequenceNumber = 0;
        while (true)
        {
            sequenceNumber++;
            string input = Console.ReadLine();
            if (input == "Clone them!")
            {
                Console.WriteLine("Best DNA sample {0} with sum: {1}.", bestSequenceNumber, bestSum);
                Console.WriteLine(string.Join(" ", result));
                return;
            }
            int[] inputArr = input
                .Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int currentStartIndex = number - 1;
            int currentSum = inputArr.Sum();
            int currentLongestSequence = 0;
            for (int i = 0; i < number; i++)
            {
                if (inputArr[i] == 1)
                {
                    int StartLocal = i;
                    int LenghtLocal = 1;
                    for (int j = i + 1; j < number; j++)
                    {
                        if (inputArr[j] == 1)//не сме ударили нула и искаме още да расте дължината на събстринга
                        {
                            LenghtLocal++;
                        }
                        if (inputArr[j] == 0 || j == number - 1)//ударили сме нулата/края на масива и трябва или да запишем това ако е по-добро от домомента за този ред или да го подминем след което брейквам вътрешния цикъл
                        {
                            if (LenghtLocal > currentLongestSequence)
                            {
                                currentLongestSequence = LenghtLocal;
                                currentStartIndex = StartLocal;
                            }
                            break;
                        }
                    }
                }
            }
            if (currentLongestSequence > bestLongestSequence ||
               (currentLongestSequence == bestLongestSequence & currentStartIndex < bestStartIndex) ||
               (currentLongestSequence == bestLongestSequence & currentStartIndex == bestStartIndex & currentSum > bestSum))
            {
                result = inputArr;
                bestStartIndex = currentStartIndex;
                bestSum = currentSum;
                bestLongestSequence = currentLongestSequence;
                bestSequenceNumber = sequenceNumber;
            }
        }
    }
}