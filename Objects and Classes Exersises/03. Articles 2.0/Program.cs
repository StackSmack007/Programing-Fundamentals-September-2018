using System;
using System.Linq;

class Program
{
    static void Main()
    {
        
        int numberOfArticles = int.Parse(Console.ReadLine());
        Article[] result = new Article[numberOfArticles];
        for (int i = 0; i < numberOfArticles; i++)
        {
           Article current = new Article(Console.ReadLine());
            result[i] = current;
        }
        string sortingCriteria = Console.ReadLine();
        if (sortingCriteria== "title")
        {
            result = result.OrderBy(x => x.Title).ToArray();
        }
        if (sortingCriteria == "content")
        {
            result = result.OrderBy(x => x.Content).ToArray();
        }
        if (sortingCriteria == "author")
        {
            result = result.OrderBy(x => x.Author).ToArray();
        }
        foreach (Article item in result)
        {
Console.WriteLine(item.ToString());
        }
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

    public string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}