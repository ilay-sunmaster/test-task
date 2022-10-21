namespace litres;

public class Book
{
    public int Id  { get; }
    public string Name { get; }
    public string Url { get; }
    public string Author { get; }
    public string Description { get; }

    public Book(int id, string name, string url, string author, string description)
    {
        Id = id;
        Name = name;
        Url = url;
        Author = author;
        Description = description;
    }
}
