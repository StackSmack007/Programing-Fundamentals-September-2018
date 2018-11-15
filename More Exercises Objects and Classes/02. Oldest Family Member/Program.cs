using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());
        Family theFamily = new Family();
        for (int i = 0; i < numberOfInputs; i++)
        {
            string[] inputArr = Console.ReadLine().Split();
            Person newbee = new Person
            {
                Name = inputArr[0],
                Age = int.Parse(inputArr[1])
            };
            theFamily.AddMember(newbee);
        }
        Person theOldestMember = theFamily.Oldest();
        Console.WriteLine(theOldestMember.Name+" "+theOldestMember.Age);
    }
}
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    }
class Family
{
    public List<Person> Band { get; set; } = new List<Person>();
    public void AddMember(Person newCommer)
    {
        Band.Add(newCommer);
    }
    public Person Oldest()
    {
        return Band.OrderByDescending(x => x.Age).First();
    }
}