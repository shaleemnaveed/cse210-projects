public class Video
{
    // Attributes:
    private string _title;
    private string _author;
    private double _length;
    private List<Comment> _comments = new List<Comment>();

    // Constructors:
    public Video(string title, string author, double length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    // Getters:
    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public double GetLength()
    {
        return _length;
    }
    public List<Comment> GetComments()
    {
        return _comments;
    }

    // Methods:
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }
    public int NumberOfComments()
    {
        return _comments.Count;
    }
}