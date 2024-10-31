using System;
using System.Collections.Generic;

namespace LibraryManagement
{
    public class Library
    {
        public List<string> Books = new List<string>();
        public List<string> Members = new List<string>();

        public void AddBook(string book)
        {
            Books.Add(book);
            Console.WriteLine("¡Libro agregado a la biblioteca!");
        }

        public void RegisterMember(string member)
        {
            Members.Add(member);
            Console.WriteLine("¡Nuevo miembro registrado!");
        }

        public void BorrowBook(string member, string book)
        {
            if (Members.Contains(member) && Books.Contains(book))
            {
                Books.Remove(book);
                Console.WriteLine($"{member} prestó el libro {book}!");
            }
            else
            {
                Console.WriteLine("¡Préstamo fallido!");
            }
        }

        public void ReturnBook(string member, string book)
        {
            Books.Add(book);
            Console.WriteLine($"{member} devolvió el libro {book}!");
        }

        public void PrintBooks()
        {
            Console.WriteLine("Libros en la Biblioteca:");
            foreach (var book in Books)
            {
                Console.WriteLine(book);
            }
        }

        public void PrintMembers()
        {
            Console.WriteLine("Miembros de la Biblioteca:");
            foreach (var member in Members)
            {
                Console.WriteLine(member);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Library library = new Library();
            library.AddBook("Patrones de Diseño");
            library.RegisterMember("Alicia");

            library.BorrowBook("Alicia", "Patrones de Diseño");
            library.ReturnBook("Alicia", "Patrones de Diseño");

            library.PrintBooks();
            library.PrintMembers();
        }
    }
}
