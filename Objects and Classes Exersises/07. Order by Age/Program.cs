using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<Person> faceBook = new List<Person>();
        while (true)
        {
            string[] input = Console.ReadLine().Split(' ');
            if (input[0] == "End")
            {
                break;
            }
            Person currentPerson = new Person
            {
                Name = input[0],
                Id = input[1],
                Age = int.Parse(input[2])
            };
            faceBook.Add(currentPerson);
        }
        foreach (var humanoid in faceBook.OrderBy(x => x.Age))
        {
            Console.WriteLine($"{humanoid.Name} with ID: {humanoid.Id} is {humanoid.Age} years old.");
        }
    }
}
class Person
{
    public string Name { get; set; }
    public string Id { get; set; }
    public int Age { get; set; }
}