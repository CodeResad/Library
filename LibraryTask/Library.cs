using System.Reflection;

namespace LibraryTask;

public class Library
{
    public string Name { get; set; }
    Book[] books;

    public Library(string name)
    {
        Name = name;
        books = new Book[0];
    }

    public void AddBook(Book book)
    {
        Array.Resize(ref books, books.Length + 1);
        books[books.Length - 1] = book;
        Console.WriteLine("Book added!");
    }
    
    public void RemoveBook(int id)
    {
        int startIndex = -1;
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i].Id == id)
            {
                startIndex = i;
                break;
            }
        }

        if (startIndex != -1)
        {
            for (int i = startIndex; i < books.Length - 1; i++)
            {
                books[i] = books[i + 1];
            }
            Array.Resize(ref books, books.Length - 1);
            Console.WriteLine($"Book ID {id} has been removed.");
            
        }
        else
        {
            Console.WriteLine($"Book ID {id} not found!");
        }
    }
    
    public Book GetBookById(int id)
    {
        foreach (Book item in books)
        {
            if (item.Id == id)
            {
                return item;
            }
        }

        return null;
    }
    
    public Book GetBook(string name)
    {
        foreach (Book item in books)
        {
            if (item.Name == name)
            {
                return item;
            }
        }

        return null;
    }

    public void GetAllBooks()
    {
        foreach (Book item in books)
        {
            Console.WriteLine(item);
        }
    }

    public void Update(int id, Book newBook)
    {
        foreach (Book item in books)
        {
            if (item != null && item.Id == id)
            {
                item.Name = newBook.Name;
                item.Price = newBook.Price;
                item.AuthorName = newBook.AuthorName;
                
                
                Console.WriteLine($"Book with ID {id} has been updated.");
                
                Type type = typeof(Book);
                var field = type.GetField("_id", BindingFlags.NonPublic | BindingFlags.Static);
                int fieldValue = (int)field.GetValue(null);
                
                fieldValue--;
                
                field.SetValue(null, fieldValue);
                
                return;
            }
        }
        
        Console.WriteLine($"Book with ID {id} not found.");
    }
}