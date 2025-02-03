using System;

namespace Biblioteksystem
{
    class Program
    {
        static void Main()
        {
            var book = new Book("Tittel på bok", "Forfatter Navn", 2023);

            Console.WriteLine($"Bok: {book.Title} av {book.Author}, Utgitt: {book.PublicationYear}, Status: {book.Status}");

            book.ChangeStatus(BookStatus.Tilgjengelig);
            Console.WriteLine($"Ny status: {book.Status}");

            try
            {
                book.ChangeStatus(BookStatus.Reservert);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}