namespace LibraryTask;

public class Book
{
    private static int _id;
    public int Id { get; }
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public double Price { get; set; }

    public Book(string name, string authorName, double price)
    {
        _id++;
        Id = _id;
        Name = name;
        AuthorName = authorName;
        Price = price;
    }

    public string ShowInfo()
    {
        return $"Id: {Id}, Name: {Name}, AuthorName: {AuthorName}, Price: {Price}";
    }

    public override string ToString()
    {
        return ShowInfo();
    }
}