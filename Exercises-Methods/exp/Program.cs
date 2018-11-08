using System;
using System.Collections.Generic;
using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();



            while (true)
            {
                var input = Console.ReadLine().Split().ToList();
                if (input[0] == "end")
                {
                    break;
                }

                if (input[0] == "exchange")
                {
                    var index = int.Parse(input[1]);
                    if (index >= numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    else
                    {
                        var currentList = numbers.Take(index + 1).ToList();
                        var second = numbers.Skip(index + 1).ToList();
                        numbers.Clear();
                        numbers.AddRange(second);
                        numbers.AddRange(currentList);


                    }
                }
                else if (input[0] == "first")
                {
                    var count = int.Parse(input[1]);
                    if (count > numbers.Count || count < 0)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    else
                    {
                        if (input[2] == "even")
                        {
                            var currentList = new List<int>();
                            var counter = 0;
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (counter == count)
                                {
                                    break;
                                }

                                if (numbers[i] % 2 == 0)
                                {
                                    currentList.Add(numbers[i]);
                                    counter++;
                                }
                            }

                            Console.WriteLine($"[{String.Join(", ", currentList)}]");
                            currentList.Clear();
                            continue;

                        }
                        else if (input[2] == "odd")
                        {
                            var currentList = new List<int>();
                            var counter = 0;
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (counter == count)
                                {
                                    break;
                                }

                                if (numbers[i] % 2 != 0) // check for 0
                                {
                                    currentList.Add(numbers[i]);
                                    counter++;
                                }
                            }

                            Console.WriteLine($"[{String.Join(", ", currentList)}]");
                            currentList.Clear();
                            continue;
                        }
                    }
                }
                else if (input[0] == "last")
                {
                    var count = int.Parse(input[1]);
                    if (count > numbers.Count || count < 0)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    else
                    {
                        if (input[2] == "even")
                        {
                            var currentList = new List<int>();
                            var counter = 0;

                            for (int i = numbers.Count - 1; i >= 0; i--)
                            {
                                if (counter == count)
                                {
                                    break;
                                }

                                if (numbers[i] % 2 == 0)
                                {
                                    currentList.Add(numbers[i]);
                                    counter++;
                                }
                            }

                            currentList.Reverse();
                            Console.WriteLine($"[{String.Join(", ", currentList)}]");
                            currentList.Clear();
                            continue;

                        }
                        else if (input[2] == "odd")
                        {
                            var currentList = new List<int>();
                            var counter = 0;

                            for (int i = numbers.Count - 1; i >= 0; i--)
                            {
                                if (counter == count)
                                {
                                    break;
                                }

                                if (numbers[i] % 2 != 0) // check for 0
                                {
                                    currentList.Add(numbers[i]);
                                    counter++;
                                }
                            }
                            currentList.Reverse();
                            Console.WriteLine($"[{String.Join(", ", currentList)}]");
                            currentList.Clear();
                            continue;
                        }
                    }
                }







                else if (input[0] == "max")
                {
                    var bestValue = int.MinValue;
                    var bestIndex = 0;
                    bool isFound = false;
                    if (input[1] == "even")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 == 0)
                            {
                                if (numbers[i] >= bestValue)
                                {
                                    bestValue = numbers[i];
                                    bestIndex = i;
                                    isFound = true;
                                }
                            }
                        }
                    }
                    else if (input[1] == "odd")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 != 0)
                            {
                                if (numbers[i] >= bestValue)
                                {
                                    bestValue = numbers[i];
                                    bestIndex = i;
                                    isFound = true;
                                }
                            }
                        }
                    }
                    if (isFound == false)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(bestIndex);
                    }
                    isFound = false;
                }

                else if (input[0] == "min")
                {
                    var bestValue = int.MaxValue;
                    var bestIndex = 0;
                    bool isFound = false;
                    if (input[1] == "even")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 == 0)
                            {
                                if (numbers[i] <= bestValue)
                                {
                                    bestValue = numbers[i];
                                    bestIndex = i;
                                    isFound = true;
                                }
                            }
                        }
                    }
                    else if (input[1] == "odd")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 != 0)
                            {
                                if (numbers[i] <= bestValue)
                                {
                                    bestValue = numbers[i];
                                    bestIndex = i;
                                    isFound = true;
                                }
                            }
                        }
                    }




                    if (isFound == false)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(bestIndex);
                    }
                    isFound = false;
                }


            }

            Console.WriteLine($"[{String.Join(", ", numbers)}]");
        }
    }
