using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1Library
{
    class PaperBook : Book
    {
        private int copiesNumber;
        public PaperBook(int copiesNumber, string title, string bookAuthor, string bookGenre) : base(title, bookAuthor, bookGenre) //This constractor is for the library's inputs of paper books.
        {
            this.copiesNumber = copiesNumber;
        }
        public PaperBook(string title, string bookAuthor, string bookGenre) : base(title, bookAuthor, bookGenre) //This constractor is for the client's inputs (so he won't have to insert number of copies)
        {

        }

        public int getCopiesNumber()
        {
            return this.copiesNumber;
        }

        public void setCopiesNumber(int copiesNumber)
        {
            this.copiesNumber = copiesNumber;
        }

        public void increaseCopiesNumber()
        {
            this.copiesNumber++;
        }
        public void decreaseCopiesNumber()
        {
            this.copiesNumber--;
        }
        public override string ToString()
        {
            //toLower function returns the paperbook string in lowercase letters, so as the client's input (just for the values he's checking).
            return this.title.ToLower() + ", " +this.GetType().ToString().Split('.')[1] + ", " + this.bookAuthor.ToLower() + ", " + this.bookGenre+ ", number of available copies- "+ this.copiesNumber;
        }
    }// this.GetType().ToString().Split('.')[1] so it returns obly the book type without the library object 
}
