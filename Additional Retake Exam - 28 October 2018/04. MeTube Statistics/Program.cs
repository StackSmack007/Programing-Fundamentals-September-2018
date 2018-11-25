using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string orderCriteria = "";
        Dictionary<string, Video> videoAndStats = new Dictionary<string, Video>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "stats time")
            {
                orderCriteria = Console.ReadLine();
                break;
            }
            if (input.Contains("-"))
            {
                string[] videoAndViews = input.Split('-');
                string name = videoAndViews[0];
                int views = int.Parse(videoAndViews[1]);
                if (videoAndStats.ContainsKey(name))
                {
                    videoAndStats[name].Views += views;
                }
                else
                {
                    videoAndStats[name] = new Video { Views = views };
                }
            }
            if (input.Contains(":"))
            {
                string[] videoAndViews = input.Split(':');
                int oppinion = videoAndViews[0] == "like" ? 1 : -1;
                string name = videoAndViews[1];
                if (!videoAndStats.ContainsKey(name))
                {
                    continue;
                }
                videoAndStats[name].Likes += oppinion;
            }
        }
        if (orderCriteria == "by views")
        {
            videoAndStats = videoAndStats.OrderByDescending(x => x.Value.Views).ToDictionary(x => x.Key, x => x.Value);
        }
        else
        {
            videoAndStats = videoAndStats.OrderByDescending(x => x.Value.Likes).ToDictionary(x => x.Key, x => x.Value);
        }
        foreach (var kvp in videoAndStats)
        {
            Console.WriteLine($"{kvp.Key} - {kvp.Value.Views} views - {kvp.Value.Likes} likes");
        }
    }
}
class Video
{
    public int Views { get; set; } = 0;
    public int Likes { get; set; } = 0;
}