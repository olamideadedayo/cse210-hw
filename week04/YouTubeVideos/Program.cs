using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create videos
        Video video1 = new Video("How to Cook Jollof Rice", "NaijaChef", 420);
        video1.AddComment(new Comment("Ada", "This recipe is amazing!"));
        video1.AddComment(new Comment("Chinedu", "I tried it and it worked perfectly."));
        video1.AddComment(new Comment("Zainab", "Can you do one for fried rice too?"));

        Video video2 = new Video("DIY Solar Panel Setup", "GreenTech", 600);
        video2.AddComment(new Comment("Tunde", "Very informative, thanks!"));
        video2.AddComment(new Comment("Ngozi", "Where can I buy the materials?"));
        video2.AddComment(new Comment("Emeka", "Please do a follow-up video."));

        Video video3 = new Video("Learn C# in 10 Minutes", "CodeQuick", 580);
        video3.AddComment(new Comment("Blessing", "This was so helpful!"));
        video3.AddComment(new Comment("Ifeanyi", "I wish it was longer."));
        video3.AddComment(new Comment("Kemi", "Great intro to C#!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display videos and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}

// Video class definition
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

// Comment class definition
public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}
