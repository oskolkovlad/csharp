using System;
using System.Collections;

namespace Yield
{
    class Program
    {
        static void Main(string[] args)
        {
            // Итератор по сути представляет блок кода, который использует оператор yield для перебора набора значений.
            // Данный блок кода может представлять тело метода, оператора или блок get в свойствах.

            // Итератор использует две специальных инструкции:
            // - yield return: определяет возвращаемый элемент
            // - yield break: указывает, что последовательность больше не имеет элементов


            Library library = new Library();
            foreach(Book b in library.GetBooks(5))
            {
                Console.WriteLine(b.Name);
            }

            Console.ReadKey();
        }
    }

    class Book
    {
        public string Name { get; private set; }

        public Book(string name)
        {
            Name = name;
        }
    }

    class Library
    {
        private Book[] books;

        public Library()
        {
            books = new Book[]
            {
                new Book("Война и мир"),
                new Book("Преступление и наказание"),
                new Book("Мастер и Маргарита")
            };
        }

        private int Length => books.Length;

        //public IEnumerator GetEnumerator(int max)
        public IEnumerable GetBooks(int max) // для именованного IEnumerable
        {
            for (var i = 0; i < max; i++)
            {
                if(i == Length)
                {
                    yield break;
                }

                yield return books[i];
            }

            //yield return books[0].Name;
            //yield return books[1].Name;
            //yield return books[2].Name;
        }
    }
}
