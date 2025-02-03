using System;

namespace Biblioteksystem
{
    public enum BookStatus
    {
        Bestilt,
        Tilgjengelig,
        Utlånt,
        Reservert,
        Tapt
    }

    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int PublicationYear { get; private set; }
        public BookStatus Status { get; private set; }

        public Book(string title, string author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            Status = BookStatus.Bestilt;
        }

        public void ChangeStatus(string trigger)
        {
            switch (trigger)
            {
                case "Levering":
                    if (Status == BookStatus.Bestilt)
                        Status = BookStatus.Tilgjengelig;
                    break;

                case "Lån":
                    if (Status == BookStatus.Tilgjengelig)
                        Status = BookStatus.Utlånt;
                    break;

                case "Reserver":
                    if (Status == BookStatus.Utlånt)
                        Status = BookStatus.Reservert;
                    break;

                case "Tilbakelevert":
                    if (Status == BookStatus.Reservert)
                        Status = BookStatus.Utlånt;
                    break;

                case "Tapt":
                    if (Status == BookStatus.Tilgjengelig || Status == BookStatus.Utlånt || Status == BookStatus.Reservert)
                        Status = BookStatus.Tapt;
                    break;

                default:
                    throw new InvalidOperationException($"Ugyldig statusovergang: {trigger} fra {Status}");
            }
        }

        public override string ToString()
        {
            return $"Bok: {Title} av {Author}, Utgitt: {PublicationYear}, Status: {Status}";
        }
    }
}