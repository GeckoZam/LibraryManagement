# Library Management
Aquí tienes un ejemplo de **código malo en C#** para un caso de un sistema básico de **Gestión de Biblioteca** en una aplicación .NET 8. Este ejemplo contiene código desordenado que no implementa patrones de diseño y presenta varios problemas de **malos olores de código**.

---

### Escenario del Problema

Un sistema sencillo de biblioteca debe rastrear libros, miembros y préstamos. Sin embargo, la implementación actual es **código espagueti**, donde todas las responsabilidades están mezcladas, y no se aplica **encapsulamiento, SRP (Principio de Responsabilidad Única) ni patrones de diseño**. Este código necesita refactorización aplicando patrones GoF (Gang of Four).

---

### Código Malo en C# (dotnet 8) 🚨

```csharp
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
```

---

### Tabla de Objetivos de Refactorización

| Objetivo | Problema | Solución Sugerida |
|-----------|---------|--------------------|
| **1** | **Falta de separación de responsabilidades** – todas las responsabilidades están en una sola clase. | Aplicar el patrón **Facade** para proporcionar una interfaz unificada. |
| **2** | **Falta de encapsulamiento** – las listas están expuestas directamente. | Usar **Encapsulamiento** y modificadores de acceso privados con métodos getters/setters adecuados. |
| **3** | **Acciones codificadas** – poca flexibilidad para manejar nuevos tipos de ítems o acciones. | Utilizar el patrón **Strategy** para la lógica de préstamo, permitiendo variar políticas de préstamo. |
| **4** | **Lógica duplicada** en `BorrowBook` y `ReturnBook`. | Aplicar el patrón **Template Method** para manejar pasos genéricos de transacciones. |
| **5** | **Obsesión por tipos primitivos** – `Books` y `Members` son cadenas simples. | Usar el patrón **Composite** para crear objetos ricos que representen libros y miembros. |
| **6** | **Falta de estrategia de manejo de errores** para libros/miembros inexistentes. | Implementar el patrón **Chain of Responsibility** para mejorar el manejo de errores. |
| **7** | **Problema de escalabilidad** – el sistema se vuelve complejo al agregar nuevas entidades (por ejemplo, DVDs). | Introducir el patrón **Abstract Factory** para manejar la creación de ítems. |
| **8** | **Manipulación directa de listas** – las colecciones se modifican directamente. | Usar el patrón **Iterator** para navegar las colecciones de forma segura. |
| **9** | **Adición/eliminación manual de ítems** – falta de un enfoque flexible de gestión de inventario. | Implementar el patrón **Factory Method** para estandarizar la creación de objetos. |
| **10** | **Métodos monolíticos** que son difíciles de probar o reutilizar. | Aplicar el patrón **Command** para encapsular y separar comandos (por ejemplo, `AddBook`, `BorrowBook`). |

---

Utiliza esta tabla y los **patrones de diseño** para refactorizar el sistema mientras mejoras la **legibilidad, modularidad y extensibilidad** del código. El objetivo es transformar el código de gestión de biblioteca en una aplicación bien estructurada utilizando patrones GoF y siguiendo los **principios SOLID**.
