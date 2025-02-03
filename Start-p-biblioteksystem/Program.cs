using System;

namespace Biblioteksystem
{
    class Program
    {
        static void Main()
        {
            var book = new Book("Tittel på bok", "Forfatter Navn", 2023);
            Console.WriteLine(book);

            while (true)
            {
                Console.WriteLine("\nVelg en handling:");
                Console.WriteLine("1. Sett status til Tilgjengelig");
                Console.WriteLine("2. Sett status til Utlånt");
                Console.WriteLine("3. Sett status til Reservert");
                Console.WriteLine("4. Sett status til Tapt");
                Console.WriteLine("5. Avslutt");
                Console.Write("Ditt valg: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        book.ChangeStatus("Levering");
                        break;
                    case "2":
                        book.ChangeStatus("Lån");
                        break;
                    case "3":
                        book.ChangeStatus("Reserver");
                        break;
                    case "4":
                        book.ChangeStatus("Tapt");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Ugyldig valg. Prøv igjen.");
                        break;
                }

                Console.WriteLine(book);
            }
        }
    }
}
