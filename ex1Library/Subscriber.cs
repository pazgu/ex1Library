using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1Library
{
    class Subscriber 
    {
        private string firstName;
        private string lastName;
        private Book[] subscriberBooks = new Book[3];
        private int numberOfLoanPaperBooks;
        
        public Subscriber(string firstName, string lastName, Book[] subscriberBooks) 
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.subscriberBooks = subscriberBooks;
            this.numberOfLoanPaperBooks = 0; //for the function of loaning books. Each subscriber starts with 0 books. 
        }

        public Subscriber(string firstName, string lastName) 
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.numberOfLoanPaperBooks = 0;
        }
        public string getFirstName()
        {
            return this.firstName;
        }
        public void setFirstName(string firstName)
        {
            this.firstName = firstName;
        }
        public string getLastName()
        {
            return this.lastName;
        }
        public void setLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public Book [] getSubscriberBooks()
        {
            return this.subscriberBooks;
        }

        public void setSubscriberBooks(Book[] subscriberBooks)
        {
            this.subscriberBooks = subscriberBooks;
        }
        public int getNumberOfLoanPaperBooks()
        {
            if (numberOfLoanPaperBooks< 4) { //The number of loaned books will be limited to 3. If it won't, the number of loaded books will reset to 0.
                return this.numberOfLoanPaperBooks;
            }
            else {
                numberOfLoanPaperBooks=0;
                return this.numberOfLoanPaperBooks;
            }
        }
        public void setNumberOfLoanPaperBooks(int numberOfLoanPaperBooks)
        {
            this.numberOfLoanPaperBooks = numberOfLoanPaperBooks;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is not Subscriber)
                return false;
            Subscriber sb = (Subscriber)obj;
            return (this.firstName.ToLower() == sb.firstName.ToLower() && this.lastName.ToLower() == sb.lastName.ToLower()); //So any client's input will contain just small lowercase letters (just as the object's.)
        }
        public override string ToString()
        {
            return this.firstName + ", " + this.lastName;
        }
    }
}


