using System;
using System.Collections.Generic;
using System.Text;

namespace LazyCollection
{
    
    public class Reader
    {
        //Library library = new Library();


        // Lazy<T> гарантирует нам, что объект будет создан только тогда, когда в нем есть необходимость.
        Lazy<Library> library = new Lazy<Library>();

        public void ReadBook()
        {
            // А чтобы обратиться к самой библиотеке и ее методам, надо использовать выражение library.
            // Value - это и есть объект Library.
            library.Value.GetBook();
            Console.WriteLine("Читаю бумажную книгу");
        }

        public void ReadEBook()
        {
            Console.WriteLine("Читаю электронную книгу!");
        }
    }
    public class Library
    {
        private string[] books = new string[99];

        public void GetBook()
        {
            Console.WriteLine("Выдаем книгу читателю!");
        }
    }
}
