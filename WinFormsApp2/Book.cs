using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace WinFormsApp2
{
    public class Book : IComparable<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int NoOfPages { get; set; }

        public Book(string title, string author, int noOfPages)
        {
            Title = title;
            Author = author;
            NoOfPages = noOfPages;
        }

        public Book() { }

        public override string ToString() { return Title + Author + NoOfPages; }

        public int CompareTo(Book other)
        {
            return this.NoOfPages.CompareTo(other.NoOfPages);
        }
    }
}
