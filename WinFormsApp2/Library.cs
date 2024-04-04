using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class Library
    {
        public List<Book> books { get; set; }
        public Library()
        {
            books = new List<Book>();
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public static implicit operator Library?(List<Book>? v)
        {
            throw new NotImplementedException();
        }

    }
}
