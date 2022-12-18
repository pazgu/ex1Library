using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1Library
{
    class Library
    {
        public Book[] books;
        public Subscriber[] subscribers;

        public Library(Book[] books, Subscriber[] subscribers)
        {
            this.books = books;
            this.subscribers = subscribers;
        }
        public void AddBook() //The function will add a book to the library due to the client input.
        {
            Console.WriteLine("Please enter the book type (D - Digital, P - Paper)");
            string bookType = Console.ReadLine().ToUpper(); //So the client could type d or p in small letters too.
            string bookTitle, bookAuthor, bookGenre;
            if (bookType == "D")
            {
                Console.WriteLine("Please enter the file size: ");
                bool isFileSizeDouble = double.TryParse(Console.ReadLine(), out double fileSize); //Checking if input has double value or not.
                Console.WriteLine("Please enter the book title: ");
                bookTitle = Console.ReadLine(); 
                bool isBookTitleNumeric = int.TryParse(bookTitle, out _); // so it's possible to add digits to the title but not just digits
                Console.WriteLine("Please enter the book's author name: ");
                bookAuthor = Console.ReadLine();
                bool isBookAuthorNumeric = bookAuthor.Any(char.IsDigit); //so the author's name won't contain numbers
                Console.WriteLine("Please enter the book genre name: ");
                bookGenre = Console.ReadLine();
                bool isBookGenreNumeric = bookGenre.Any(char.IsDigit);
                if ((isFileSizeDouble) && (!isBookTitleNumeric) && (!isBookAuthorNumeric) && (!isBookGenreNumeric) && (fileSize != null) && (bookTitle != "") && (bookAuthor != "") && (bookGenre != ""))
                { //Continue just if the input is NaN and not empty. 
                    Book newDigitalBook = new DigitalBook(fileSize, bookTitle, bookAuthor, bookGenre);
                    for (int i = 0; i < books.Length; i++)
                    {
                        if (books[i] != null)
                        {
                            if (books[i].Equals(newDigitalBook) && books[i] is DigitalBook)
                            {
                                Console.WriteLine("\nBook is already exists.");
                                break;
                            }
                            if (books[i].Equals(newDigitalBook) && books[i] is PaperBook) //So it won't be an option to add book that already exists, even if is a paper book 
                            {
                                Console.WriteLine("\nBook is already exists and it has paper version");
                                break;
                            }
                        }
                        else
                        {
                            books[i] = newDigitalBook;
                            Console.WriteLine("\nSuccess. New Digital book is added.");
                            break;
                        }
                    }
                }
                else
                    Console.WriteLine("\nInput can't be empty or contain numbers (besides file size- that has to be number). Please follow the instraction and enter the details again.");
            }
            else if (bookType == "P")
            {
                Console.WriteLine("Please enter the book title: ");
                bookTitle = Console.ReadLine();
                bool isBookTitleNumeric = int.TryParse(bookTitle, out _); 
                Console.WriteLine("Please enter the book's author name: ");
                bookAuthor = Console.ReadLine();
                bool isBookAuthorNumeric = bookAuthor.Any(char.IsDigit); //so the author's name won't contain numbers
                Console.WriteLine("Please enter the book genre name: ");
                bookGenre = Console.ReadLine();
                bool isBookGenreNumeric = bookGenre.Any(char.IsDigit); ;
                int numberOfCopies = 1;
                if ((!isBookTitleNumeric) && (!isBookAuthorNumeric) && (!isBookAuthorNumeric) && (bookTitle != "") && (bookAuthor != "") && (bookGenre != ""))
                { //Continue just if the input is NaN and not empty. 
                    Book newPaperBook = new PaperBook(numberOfCopies, bookTitle, bookAuthor, bookGenre);
                    for (int i = 0; i < books.Length; i++)
                    {
                        if (books[i] != null)
                        {
                            if (books[i].Equals(newPaperBook) && books[i] is PaperBook)
                            {
                                PaperBook PaperBook = (PaperBook)books[i];
                                PaperBook.increaseCopiesNumber();
                                books[i] = PaperBook;
                                Console.WriteLine("\nBook is already exists.");
                                break;
                            }
                            if (books[i].Equals(newPaperBook) && books[i] is DigitalBook) //So it won't be an option to add book that already exists, even if is a digital book 
                            {
                                Console.WriteLine("\nBook is already exists and it has digital version.");
                                break;
                            }
                        }
                        else
                        {
                            books[i] = newPaperBook;
                            Console.WriteLine("\nSuccess. New paper book is added.");
                            break;
                        }
                    }
                }
                else
                    Console.WriteLine("\nInput can't be empty or contain numbers. Please follow the instraction and enter the details again.");
            }
            else // If the client type something that isn't d or p character
            {
                Console.WriteLine("\nInput is wrong. Please enter D for digital book or P for paper book.");
            }
        }
        public void AddSubscriber()
        {
            Console.WriteLine("Please enter your first name: ");
            string firstName = Console.ReadLine();
            bool isFirstNameNumeric = firstName.Any(char.IsDigit); //Checking if input contains number or not.
            Console.WriteLine("Please enter your last name: ");
            string lastName = Console.ReadLine();
            bool isLastNameNumeric = lastName.Any(char.IsDigit);
            if ((!isFirstNameNumeric) && (!isLastNameNumeric) && (firstName != "") && (lastName != "")) //Continue just if the input doesn't contain digits and isn't empty.  
            {
                Subscriber subscriber = new Subscriber(firstName, lastName);
                for (int i = 0; i < subscribers.Length; i++)
                {
                    if (subscribers[i] != null)
                    {
                        if (subscribers[i].Equals(subscriber))
                        {
                            Console.WriteLine("\nSubscriber already exists. Log in to start reading.");
                            break;
                        }
                    }
                    else
                    {
                        subscribers[i] = subscriber;
                        Console.WriteLine("\nSuccess. You are now part of our system :).");
                        break;
                    }
                }
            }
            else
                Console.WriteLine("\nInput can't be empty or contain digits. Please enter your first and last name again.");
        }
        public void LoanBook() 
        {
            Console.WriteLine("Please enter your first name: ");
            string firstName = Console.ReadLine();
            bool isFirstNameNumeric = firstName.Any(char.IsDigit);
            Console.WriteLine("Please enter your last name: ");
            string lastName = Console.ReadLine();
            bool isLastNameNumeric = lastName.Any(char.IsDigit);
            Console.WriteLine("Please enter the book title: ");
            string bookTitle = Console.ReadLine();
            bool isBookTitleNumeric = int.TryParse(bookTitle, out _);
            Console.WriteLine("Please enter the book's author name: ");
            string bookAuthor = Console.ReadLine();
            bool isBookAuthorNumeric = bookAuthor.Any(char.IsDigit);
            PaperBook paperbook;
            bool foundBook = false, foundSubscriber = false, copiesnumber = true;
            if ((!isFirstNameNumeric) && (!isLastNameNumeric) && (!isBookTitleNumeric) && (!isBookAuthorNumeric) && (firstName != "") && (lastName != "") && (bookTitle != "") && (bookAuthor != ""))
            {
                for (int i = 0; i < subscribers.Length; i++) //For all subscribers in the library:
                {
                    Subscriber subscriber = new Subscriber(firstName, lastName);
                    if (subscribers[i] != null)
                    {
                        if (subscribers[i].Equals(subscriber))
                        {
                            foundSubscriber = true;
                            if (subscribers[i].getNumberOfLoanPaperBooks() >= 3)
                            {
                                Console.WriteLine("Subscriber has maximum number of allowed books on loan");
                                break;
                            }
                            for (int j = 0; j < books.Length; j++)
                            {
                                Book book = new Book(bookTitle, bookAuthor);
                                if (books[j] != null)
                                {
                                    if (books[j].Equals(book)) // Checking if book exists and if it's paper book it will decrease the number of copies.
                                    {
                                        foundBook = true;
                                        if (books[j] is PaperBook)
                                        {
                                            paperbook = (PaperBook)books[j]; //I added this vairable so I could get an access to paperbook functions 
                                            if (paperbook.getCopiesNumber() <= 0)
                                            {
                                                Console.WriteLine("All copies of the book are already taken.");
                                                copiesnumber = false;
                                                break;
                                            }
                                            paperbook.decreaseCopiesNumber();
                                            subscribers[i].setNumberOfLoanPaperBooks(subscribers[i].getNumberOfLoanPaperBooks() + 1); // number of loan books of subscriber will increase 
                                        }
                                        Book[] subscriberBooks = subscribers[i].getSubscriberBooks(); //Now we need to add the new loaned book to the subscriber's array of books
                                        for (int k = 0; k < subscriberBooks.Length; k++)
                                        {
                                            if (subscriberBooks[k] == null)
                                            {
                                                subscriberBooks[k] = new Book(bookTitle, bookAuthor);
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                            if (!foundBook)
                            {
                                Console.WriteLine("\nBook does not exist");
                                break;
                            }
                            if ((copiesnumber)) //if there is still book's copies available
                            {
                                Console.WriteLine("\nSuccess. You'd loan a book.");
                            }
                            if (subscribers[i].getNumberOfLoanPaperBooks() >= 3) //if it equals 3 after we added last book then we reached the limit
                            {
                                Console.WriteLine("\nSubscriber reached limit");
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Input can't be empty or contain numbers. Please follow the instraction and enter your details again.");
                return;
            }
            if (!foundSubscriber)
            {
                Console.WriteLine("Subscriber does not exist.");
            }
        }

        public void ReturnBook()
        {
            Console.WriteLine("Please enter your first name: ");
            string firstName = Console.ReadLine();
            bool isFirstNameNumeric = firstName.Any(char.IsDigit);
            Console.WriteLine("Please enter your last name: ");
            string lastName = Console.ReadLine();
            bool isLastNameNumeric = lastName.Any(char.IsDigit);
            Console.WriteLine("Please enter the book title: ");
            string bookTitle = Console.ReadLine();
            bool isBookTitleNumeric = int.TryParse(bookTitle, out _);
            Console.WriteLine("Please enter the book's author name: ");
            string bookAuthor = Console.ReadLine();
            bool isBookAuthorNumeric = bookAuthor.Any(char.IsDigit);
            PaperBook paperbook;
            bool foundBook = false, foundSubscriber = false, foundBookInSubscriber = false;
            if ((!isFirstNameNumeric) && (!isLastNameNumeric) && (!isBookTitleNumeric) && (!isBookAuthorNumeric) && (firstName != "") && (lastName != "") && (bookTitle != "") && (bookAuthor != ""))
            {
                for (int i = 0; i < subscribers.Length; i++) //For all subscribers in the library:
                {
                    Subscriber subscriber = new Subscriber(firstName, lastName);
                    if (subscribers[i] != null)
                    {
                        if (subscribers[i].Equals(subscriber))
                        {
                            foundSubscriber = true;
                            if (subscribers[i].getNumberOfLoanPaperBooks() == 0)
                            {
                                Console.WriteLine("Subscriber doesn't have any loan books.");
                                break;
                            }
                            for (int j = 0; j < books.Length; j++)
                            {
                                Book book = new Book(bookTitle, bookAuthor);
                                if (books[j] != null)
                                {
                                    if (books[j].Equals(book)) // Checking if book exists and if it's paper book it will decrease the number of copies.
                                    {
                                        foundBook = true;                 
                                        Book[] subscriberBooks = subscribers[i].getSubscriberBooks(); //Now we need to remove the loaned book from the subscriber's array of books
                                        for (int k = 0; k < subscriberBooks.Length; k++)
                                        {
                                            if (subscriberBooks[k] != null && subscriberBooks[k].Equals(book))
                                            {
                                                if (books[j] is PaperBook)
                                                {
                                                    paperbook = (PaperBook)books[j];
                                                    paperbook.increaseCopiesNumber();
                                                    subscribers[i].setNumberOfLoanPaperBooks(subscribers[i].getNumberOfLoanPaperBooks() - 1); // number of loan books of subscriber will decrease 
                                                }
                                                subscriberBooks[k] = null;
                                                foundBookInSubscriber = true;                                               
                                                break;
                                            }
                                        }
                                        if (!foundBookInSubscriber)
                                        {
                                            Console.WriteLine("Subscriber doesn't loaned this book");
                                        }
                                        break;
                                    }
                                }
                            }
                            if (!foundBook)
                            {
                                Console.WriteLine("\nBook doesn't exist");
                            }
                            else if (foundBookInSubscriber)
                            {
                                Console.WriteLine("Success. You'd return a book.");
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Input can't be empty or contain numbers. Please follow the instraction and enter your details again.");
                return;
            }
            if (!foundSubscriber)
            {
                Console.WriteLine("Subscriber does not exist.");
            }

        }

        public void PrintDetailsOfBook()
        {
            Console.WriteLine("Please enter the book title: ");
            string bookTitle = Console.ReadLine();
            bool isBookTitleNumeric = int.TryParse(bookTitle, out _);
            Console.WriteLine("Please enter the book's author name: ");
            string bookAuthor = Console.ReadLine();
            bool isBookAuthorNumeric = bookAuthor.Any(char.IsDigit);
            bool foundBook = false;
            if ((!isBookTitleNumeric) && (!isBookAuthorNumeric) && (bookTitle != "") && (bookAuthor != ""))
            {
                Book book = new Book(bookTitle, bookAuthor);
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i] != null && books[i].Equals(book))
                    {
                        Console.WriteLine(books[i].ToString()); //toString is an override function at digital book and paper book class.
                        foundBook = true;
                    }
                }
                if (!foundBook)
                {
                    Console.WriteLine("Book does not exist");
                }
            }
            else
                Console.WriteLine("Input can't be empty or contain numbers. Please follow the instraction and enter book details again.");
        }

        public void PrintDetailsOfBookByGenre()
        {
            Console.WriteLine("Please enter the book genre: ");
            string bookGenre = Console.ReadLine();
            bool isBookGenreNumeric = bookGenre.Any(char.IsDigit);
            string relevantBooks = "";
            int numOfRelevantBooks = 0;
            if ((!isBookGenreNumeric)&& (bookGenre != ""))
            {
                Book book = new Book();
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i] != null && bookGenre.ToLower() == books[i].getbookGenre().ToLower())
                    {
                        relevantBooks += "(" + (numOfRelevantBooks + 1) + ") " + books[i].ToString() + ", "; //numOfRelevantBooks is a variable that index on the number of books in the list
                        numOfRelevantBooks++;
                    }
                }
                if (relevantBooks != "")
                {
                    Console.WriteLine(relevantBooks.Substring(0, relevantBooks.Length - 2)); //so it prints the sliced string without the last comma.
                }
                else 
                {
                    Console.WriteLine("No books from genere " + bookGenre);
                }
            }
            else 
                Console.WriteLine("Input is wrong. Please check the input isn't empty and book's genre isn't a number.");
        }
    }
}




      

        


    
