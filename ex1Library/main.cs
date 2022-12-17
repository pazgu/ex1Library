

using ex1Library;

class Program
{
    static void Main(string[] args)
    {
        Book[] books = new Book[10]; //Array of all books in the library
        books[0]= new DigitalBook(114,"Harry Potter and the philosopher's stone", "J.K Rowling", "Science Fiction");
        books[1]= new DigitalBook(256,"A song of ice and fire", "George R. R. Martin", "Drama");
        books[2]= new DigitalBook(330,"The chesnut man", "Soren Sveistrup", "Comedy");
        books[3]= new PaperBook(5 ,"The Crown", "Peter Morgan", "Drama");
        books[4]= new PaperBook(1, "Breaking bad", "Michael Slovis", "Science Fiction");

        Subscriber[] subscribers = new Subscriber[10]; //Array of all subscribers in the library

        Book[] booksOfSubscriber1 = new Book[3]; // Array of the books of spesific subscriber (1)
        booksOfSubscriber1[0]= new DigitalBook("The chesnut man", "Soren Sveistrup", "Comedy");
        booksOfSubscriber1[1]= new PaperBook("The Crown", "Peter Morgan", "Drama");
        booksOfSubscriber1[2] = new PaperBook("Breaking bad", "Michael Slovis", "Science Fiction");
        //the line below represents subscriber who gets also value for his/hers array of books. 
        subscribers[0] = new Subscriber("Paz", "Gueta", booksOfSubscriber1);
        subscribers[0].setNumberOfLoanPaperBooks(3);

        Book[] booksOfSubscriber2 = new Book[3]; // Array of the books of spesific subscriber(2)
        //As default value of array's cells is null, I consider this array of subscriber's books as null.
        subscribers[1] = new Subscriber("Harel", "Skaat", booksOfSubscriber2);
        subscribers[1].setNumberOfLoanPaperBooks(0);

        Book[] booksOfSubscriber3 = new Book[3]; // Array of the books of spesific subscriber(3)
        booksOfSubscriber3[0] = new DigitalBook("Harry Potter and the philosopher's stone", "J.K Rowling", "Science Fiction");
        booksOfSubscriber3[1] = new DigitalBook("Harry Potter and the philosopher's stone", "J.K Rowling", "Science Fiction");
        booksOfSubscriber3[2] = new DigitalBook("Harry Potter and the philosopher's stone", "J.K Rowling", "Science Fiction");
        subscribers[2]= new Subscriber("Lior", "Menashe", booksOfSubscriber2);
        subscribers[2].setNumberOfLoanPaperBooks(3);

        Book[] booksOfSubscriber4 = new Book[3]; // Array of the books of spesific subscriber(4)
        booksOfSubscriber4[0] = new DigitalBook("A song of ice and fire", "George R. R. Martin", "Drama");
        booksOfSubscriber4[1] = new PaperBook("Breaking bad", "Michael Slovis", "Science Fiction");
        booksOfSubscriber4[2] = new PaperBook("The Crown", "Peter Morgan", "Drama");
        subscribers[3]= new Subscriber("Shiri", "Maymon", booksOfSubscriber3);
        subscribers[3].setNumberOfLoanPaperBooks(3);

        Book[] booksOfSubscriber5 = new Book[3]; // Array of the books of spesific subscriber(5)
        booksOfSubscriber5[0] = new PaperBook("The Crown", "Peter Morgan", "Drama");
        booksOfSubscriber5[1] = new PaperBook("Breaking bad", "Michael Slovis", "Science Fiction");
        subscribers[4] = new Subscriber("Ninet", "Tayeb", booksOfSubscriber4);
        subscribers[4].setNumberOfLoanPaperBooks(2);

        Library library = new Library(books, subscribers); 
        bool b = true;
        while (b == true)
        {
            Console.WriteLine("Welcome to Kotar Rishon Lezion library \n\n Press button 1-7 according to the following: \n (1) Add a new book \n (2) Add a new subscriber \n (3) Loan a prefered book \n (4) Return a book \n (5) Print book's details \n (6) Print books from the same genre type \n (7) Exit");
            string buttonNumber = Console.ReadLine();
            switch (buttonNumber)
            {
                case "1":
                    library.AddBook();
                    Console.WriteLine("\nOur collection of books:\n");
                    for (int i = 0; i < books.Length; i++)
                    {
                        if (books[i] == null)
                        {
                            break;
                        }
                        Console.WriteLine(books[i].ToString());
                    }
                    Console.WriteLine("\n");
                    break;
                case "2":
                    library.AddSubscriber();
                    Console.WriteLine("\nOur subscribers list:\n");
                    for (int i = 0; i < subscribers.Length; i++)
                    {
                        if (subscribers[i] == null)
                        {
                            break;
                        }
                        Console.WriteLine(subscribers[i].ToString());
                    }
                    Console.WriteLine("\n");
                    break;
                case "3":
                    library.LoanBook();
                    Console.WriteLine("\nOur collection of books:\n");
                    for (int i = 0; i < books.Length; i++)
                    {
                        if (books[i] == null)
                        {
                            break;
                        }
                        Console.WriteLine(books[i].ToString());
                    }
                    Console.WriteLine("\n");
                    break;
                case "4":
                    library.ReturnBook();
                    Console.WriteLine("\n");
                    break;
                case "5":
                    library.PrintDetailsOfBook();
                    Console.WriteLine("\n");
                    break;
                case "6":
                    library.PrintDetailsOfBookByGenre();
                    Console.WriteLine("\n");
                    break;
                case "7":
                    Console.WriteLine("Good bye");
                    b = false;
                    break;
                 default:
                    Console.WriteLine("\nInput is wrong. Please enter number from 1 to 7.\n");
                    break;
            }
        }
    }
}




