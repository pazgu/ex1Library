using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1Library
{
    class Book
    {
        protected string title;
        protected string bookAuthor;
        protected string bookGenre;

        public Book(string title, string bookAuthor, string bookGenre)
        {
            this.title = title;
            this.bookAuthor = bookAuthor;
            this.bookGenre = bookGenre;
            
        }
        public Book() { } 
        public Book(string title, string bookAuthor)
        {
            this.title = title;
            this.bookAuthor = bookAuthor;
        }

        public string getTitle()
        {
            return this.title;
        }

        public void setTitle(string title)
        {
            this.title = title;
        }

        public string getbookAuthor()
        {
            return this.bookAuthor;
        }

        public void setbookAuthor(string bookAuthor)
        {
            this.bookAuthor = bookAuthor;
        }

        public string getbookGenre()
        {
            return this.bookGenre;
        }

        public void setbookGenre(string bookGenre)
        {
            this.bookGenre = bookGenre;
        }

        public override bool Equals (object obj)
        {
            if (obj == null)
                return false;
            if (obj is not Book)
                return false;
            Book bk= (Book) obj;
            return (this.title.ToLower() == bk.title.ToLower() && this.bookAuthor.ToLower() == bk.bookAuthor.ToLower());

        }

        public override string ToString()
        {
            return this.title + ", " + this.bookAuthor + ", " + this.bookGenre;
        }
    }
}










    
        



    

