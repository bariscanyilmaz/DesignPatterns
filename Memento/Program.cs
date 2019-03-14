using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Isbn = "12345",
                Title="Hayvan Çiftliği",
                Author="George Orwell"

            };
            book.ShowBook();
            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.Isbn = "12312";
            book.Title = "HAYVAN Çifliği";
            book.ShowBook();

            book.RestoreFromUndo(history.Memento);
            book.ShowBook();
            Console.ReadLine();
        }
    }

    class Book
    {
        private string title;
        private string author;
        private string isbn;
        private DateTime lastEdited;

        public string Title
        {
            get { return title; }
            set { title = value; SetLastEdited(); }

        }


        public string Author
        {
            get { return author; }
            set { author = value; SetLastEdited(); }
        }
        

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; SetLastEdited(); }
        }

        private void SetLastEdited()
        {
            lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(isbn,title,author,lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            title = memento.Title;
            author = memento.Author;
            isbn = memento.Isbn;
            lastEdited = memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2}  edited: {3}", isbn,title,author,lastEdited);
        }
    }

    class Memento
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn,string title,string author,DateTime lastEdited)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento{ get; set; }

    }
}
