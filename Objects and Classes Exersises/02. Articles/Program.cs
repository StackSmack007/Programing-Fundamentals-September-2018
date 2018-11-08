using System;


class Program
{
    static void Main()
    {
        Article result = new Article(Console.ReadLine());
        int numberOfCommands = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCommands; i++)
        {
            result.Command(Console.ReadLine());
        }
        Console.WriteLine(result.ToString());
    }
}
class Article
{
    public Article(string input)
    {
        string[] arrayInput = input.Split(", ");
        if (arrayInput.Length > 1)
        {
            Title = arrayInput[0];
            Content = arrayInput[1];
            Author = arrayInput[2];
            return;
        }
    }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }

    public void Command(string input)
    {
        string[] arrayCommands = input.Split(": ");
        switch (arrayCommands[0])
        {
            case "Edit":
                Content = arrayCommands[1];
                break;
            case "ChangeAuthor":
                Author = arrayCommands[1];
                break;
            case "Rename":
                Title = arrayCommands[1];
                break;
        }
    }
    public string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}