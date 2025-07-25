using System;

class Program
{
    static void Main(string[] args)
    {
        // Video 1:
        Video video1 = new Video("Intro to C#", "Shaleem", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks."));
        video1.AddComment(new Comment("Clara", "Can you do a video on LINQ next?"));
        // Video 2:
        Video video2 = new Video("Game Development Basics", "AlexDev", 900);
        video2.AddComment(new Comment("Dana", "Excited to start game dev!"));
        video2.AddComment(new Comment("Eli", "I like your teaching style."));
        video2.AddComment(new Comment("Fay", "This made Unity much clearer."));
        // Video 3:
        Video video3 = new Video("Art for Beginners", "CreativeKat", 480);
        video3.AddComment(new Comment("George", "I'm picking up a pencil again!"));
        video3.AddComment(new Comment("Hannah", "Loved your shading tips."));
        video3.AddComment(new Comment("Ivan", "Subscribed for more content."));
        // Video 4:
        Video video4 = new Video("Entrepreneur Mindset", "BizTalks", 720);
        video4.AddComment(new Comment("Jack", "Very motivating."));
        video4.AddComment(new Comment("Lara", "Wish I saw this earlier!"));
        video4.AddComment(new Comment("Mike", "Short and powerful."));
        // List of videos:
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };
        // Displaying videos and comments:
        int count = 0;
        foreach (Video video in videos)
        {
            count++;
            Console.WriteLine($"\nVideo {count}:\n\nTitle: {video.GetTitle()}\nAuthor: {video.GetAuthor()}\nLength: {video.GetLength():F2} seconds\nNumber of comments: {video.NumberOfComments()}\n");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }
        }
        Console.WriteLine();
    }
}