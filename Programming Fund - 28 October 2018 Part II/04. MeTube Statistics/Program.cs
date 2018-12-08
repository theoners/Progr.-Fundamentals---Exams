using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._MeTube_Statistics
{
    public class Video
    {
        public string Name { get; set; }
        public int View { get; set; }
        public int Like { get; set; } 
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Video> videoList = new Dictionary<string, Video>();

            while (true)
            {
                var command = Console.ReadLine().Trim();
                if (command=="stats time")
                {
                    break;
                }

                if (command.Contains('-'))
                {
                    var input = command.Split('-', StringSplitOptions.RemoveEmptyEntries);
                    var name = input[0].Trim();
                    var views = int.Parse(input[1].Trim());
                    if (!videoList.ContainsKey(name))
                    {
                        
                        var video = new Video()
                        {
                            Name = name,
                            View = views,
                            Like = 0
                        };

                      videoList.Add(name,video);
                    }
                    else
                    {
                        videoList[name].View += views;
                    }
                }
                else
                {
                    var input = command.Split(':',StringSplitOptions.RemoveEmptyEntries);
                    var likeOrDislike = input[0].Trim();
                    var videoName = input[1].Trim();
                    if (videoList.ContainsKey(videoName))
                    {
                        if (likeOrDislike == "like")
                        {
                            videoList[videoName].Like += 1;
                        }
                        else
                        {
                            videoList[videoName].Like -= 1;
                        }
                    }
                    
                }
            }

            var sortBy = Console.ReadLine().Trim();

            if (sortBy== "by likes")
            {
                foreach (var video in videoList.OrderByDescending(x=>x.Value.Like))
                {
                    Console.WriteLine($"{video.Value.Name} - { video.Value.View} views - { video.Value.Like} likes");
                }
            }
            else
            {
                foreach (var video in videoList.OrderByDescending(x => x.Value.View))
                {
                    Console.WriteLine($"{video.Value.Name} - { video.Value.View} views - { video.Value.Like} likes");
                }
            }

        }
    }
}
