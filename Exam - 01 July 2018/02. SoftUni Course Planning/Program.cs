//10:40
using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<string> shedule = Console.ReadLine()
            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .ToList();
        while (true)
        {
            string[] inputLine = Console.ReadLine()
                        .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .ToArray();
            string command = inputLine[0];
            if (command == "course start")
            {
                goto print;
            }
            switch (command)
            {
                case "course start":
                    goto print;
                case "Add":
                    string newLesson = inputLine[1];
                    if (!shedule.Contains(newLesson))
                    {
                        shedule.Add(newLesson);
                    }
                    break;
                case "Insert":
                    string lesson = inputLine[1];
                    int index = int.Parse(inputLine[2]);
                    if (index >= shedule.Count || index < 0)
                    {
                        continue;
                    }
                    if (!shedule.Contains(lesson))
                    {
                        if (shedule[index].Contains("Exercise"))
                        {
                            shedule.Insert(index + 1, lesson);
                        }
                        else
                        {
                            shedule.Insert(index, lesson);
                        }
                    }
                    break;
                case "Remove":
                    string lessonName = inputLine[1];
                    if (shedule.Contains(lessonName))
                    {
                        shedule.Remove(lessonName);
                        if (shedule.Contains($"{lessonName}-Exercise"))
                        {
                            shedule.Remove($"{lessonName}-Exercise");
                        }
                    }
                    break;
                case "Swap":
                    string lesson1 = inputLine[1];
                    int lesson1Index = shedule.IndexOf(lesson1);
                    bool has1Exercise = shedule.Contains($"{lesson1}-Exercise");
                    string lesson2 = inputLine[2];
                    int lesson2Index = shedule.IndexOf(lesson2);
                    bool has2Exercise = shedule.Contains($"{lesson2}-Exercise");
                    if (lesson1Index > -1 & lesson2Index > -1)
                    {
                        shedule[lesson1Index] = lesson2;
                        shedule[lesson2Index] = lesson1;
                        if (has2Exercise)
                        {
                            if (has1Exercise)
                            {
                                shedule[lesson1Index + 1] = lesson2 + "-Exercise";
                                shedule[lesson2Index + 1] = lesson1 + "-Exercise";
                            }
                            else
                            {
                                shedule.Remove(lesson2 + "-Exercise");
                                lesson1Index = shedule.IndexOf(lesson2);
                                shedule.Insert(lesson1Index + 1, lesson2 + "-Exercise");
                            }
                        }
                        else if (has1Exercise)
                        {
                            shedule.Remove(lesson1 + "-Exercise");
                            lesson2Index = shedule.IndexOf(lesson1);
                            shedule.Insert(lesson2Index + 1, lesson1 + "-Exercise");
                        }
                    }
                    break;
                case "Exercise":
                    string NameOfLesson = inputLine[1];
                    int indexOfLesson = shedule.IndexOf(NameOfLesson);
                    if (indexOfLesson == -1)
                    {
                        shedule.Add(NameOfLesson);
                        shedule.Add(NameOfLesson + "-Exercise");
                    }
                    else if (indexOfLesson == shedule.Count - 1)
                    {
                        shedule.Add(NameOfLesson + "-Exercise");
                    }
                    else if (!shedule[indexOfLesson + 1].Contains("Exercise"))
                    {
                        shedule.Insert(indexOfLesson + 1, NameOfLesson + "-Exercise");
                    }
                    break;
            }
        }
        print:
        for (int i = 0; i < shedule.Count; i++)
        {
            Console.WriteLine("{0}.{1}", i + 1, shedule[i]);
        }
    }
}
//12:25