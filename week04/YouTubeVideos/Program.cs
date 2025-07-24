using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold videos
        List<Video> videos = new List<Video>();

        // Create Video 1
        Video video1 = new Video("How to Learn C# in 10 Minutes", "CodeAcademy", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial! Very helpful."));
        video1.AddComment(new Comment("Bob", "I learned so much in such a short time."));
        video1.AddComment(new Comment("Charlie", "Could you make more videos like this?"));

        // Create Video 2
        Video video2 = new Video("Top 5 Programming Languages in 2024", "TechInsider", 850);
        video2.AddComment(new Comment("David", "Python is definitely #1!"));
        video2.AddComment(new Comment("Eve", "I think Rust deserves a spot."));
        video2.AddComment(new Comment("Frank", "Thanks for the insights!"));

        // Create Video 3
        Video video3 = new Video("Building a Game in Unity", "GameDevMike", 1200);
        video3.AddComment(new Comment("Grace", "Amazing tutorial, helped me finish my first game!"));
        video3.AddComment(new Comment("Henry", "Can you do one for Unreal too?"));
        video3.AddComment(new Comment("Isabella", "Step-by-step and clear. Thank you!"));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}