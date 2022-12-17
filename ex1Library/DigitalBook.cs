using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1Library
{
    class DigitalBook: Book
    {
        private double fileSize { get; set; }
        public DigitalBook (double fileSize, string title, string bookAuthor, string bookGenre): base (title, bookAuthor, bookGenre) //This constractor is for the library's inputs of digital books.
        {
            this.fileSize = fileSize;
        }

        public DigitalBook(string title, string bookAuthor, string bookGenre) : base(title, bookAuthor, bookGenre) //This constractor is for the client's inputs (so he won't have to insert file size)
        {
          
        }

        public override string ToString()
        {

            //toLower function returns the digitalbook string in lowercase letters, so as the client's input (just for the values he's checking).
            return this.title.ToLower() + ", " + this.GetType().ToString().Split('.')[1] + ", "+ this.bookAuthor.ToLower() + ", " + this.bookGenre + ", file size: " + this.fileSize;
        }
        // this.GetType().ToString().Split('.')[1] so it returns obly the book type without the library object 
    }
}
