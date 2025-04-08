namespace LibraryTask;

class Program
{
    static void Main(string[] args)
    {
        Library lib = new Library("Axundov");

        do
        {
            Start:
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Get book by id");
            Console.WriteLine("3. Remove book");
            Console.WriteLine("4. Update Book");
            Console.WriteLine("5. Get all books");
            Console.WriteLine("6. Get book by name");
            Console.WriteLine("0. Quit");
            
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Clear();
                Console.WriteLine("Invalid input!!!");
                Console.WriteLine();
                goto Start;
            }
        
            switch (choice)
            {
                case 1:
                    Name:
                    Console.WriteLine("Enter book Name: ");
                    string name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                    {
                        goto Name;
                    }
                    
                    Author:
                    Console.WriteLine("Enter book Author: ");
                    string author = Console.ReadLine();
                    if (string.IsNullOrEmpty(author) || string.IsNullOrWhiteSpace(author))
                    {
                        goto Author;
                    }
                    
                    Price:
                    Console.WriteLine("Enter book price: ");
                    double price;
                    
                    if (!double.TryParse(Console.ReadLine(), out price))
                    {
                        Console.WriteLine("Invalid price!!!");
                        goto Price;
                    }

                    if (price < 0)
                    {
                        Console.WriteLine("Price cannot be negative!!!");
                        goto Price;
                    }
                    
                    Book newBook = new Book(name, author, price);
                    lib.AddBook(newBook);
                    
                    break;
                case 2:
                    Console.WriteLine("Enter id for book you are looking for: ");
                    int id = int.Parse(Console.ReadLine());
                    if (lib.GetBookById(id) != null)
                    {
                        Console.WriteLine(lib.GetBookById(id));
                    }
                    else
                    {
                        Console.WriteLine($"Book with id {id} not found");
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter book id for removing: ");
                    int removeId = int.Parse(Console.ReadLine());
                    
                    lib.RemoveBook(removeId);
                    break;
                case 4:
                    Console.WriteLine("Choose id for update book: ");
                    int updateId = int.Parse(Console.ReadLine());
                    
                    UpdateName:
                    Console.WriteLine("Enter new book name: ");
                    string updatedName = Console.ReadLine();
                    
                    if (string.IsNullOrEmpty(updatedName) || string.IsNullOrWhiteSpace(updatedName))
                    {
                        goto UpdateName;
                    }
                    
                    UpdateAuthor:
                    Console.WriteLine("Enter new book author: ");
                    string updatedAuthor = Console.ReadLine();
                    
                    if (string.IsNullOrEmpty(updatedAuthor) || string.IsNullOrWhiteSpace(updatedAuthor))
                    {
                        goto UpdateAuthor;
                    }
                    
                    UpdatePrice:
                    Console.WriteLine("Enter new book price: ");
                    if (!double.TryParse(Console.ReadLine(), out double updatedPrice))
                    {
                        Console.WriteLine("Invalid price!!!");
                        goto UpdatePrice;
                    }
                    if (updatedPrice < 0)
                    {
                        Console.WriteLine("Price cannot be negative!!!");
                        goto UpdatePrice;
                    }
                    
                    lib.Update(updateId, new Book(updatedName, updatedAuthor, updatedPrice));
                    break;
                case 5:
                    lib.GetAllBooks();
                    break;
                case 6:
                    Console.WriteLine("Enter Name of book you are looking for: ");
                    string search = Console.ReadLine();
                    if (lib.GetBook(search) != null)
                    {
                        Console.WriteLine(lib.GetBook(search));
                    }
                    else
                    {
                        Console.WriteLine($"Book with name \"{search}\" not found");
                    }
                    break;
                case 0:
                    return;
            }
            
        } while (true);
    }
}